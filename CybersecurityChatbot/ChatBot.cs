using System;
using System.Media;
using System.IO;

namespace CybersecurityChatbot
{
    public class ChatBot
    {
        private KeywordResponder _keywords;
        private SentimentDetector _sentiment;
        private MemoryStore _memory;
        private bool _awaitingName;
        private string _lastTopic;

        public ChatBot()
        {
            _keywords = new KeywordResponder();
            _sentiment = new SentimentDetector();
            _memory = new MemoryStore();
            _awaitingName = true;
            _lastTopic = string.Empty;
        }

        public void PlayVoiceGreeting()
        {
            string path = "greeting.wav";
            if (File.Exists(path))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.Play();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Sound error: {ex.Message}");
                }
            }
        }

        public string GetGreeting()
        {
            return "Welcome to the Cybersecurity Awareness Bot! What is your name?";
        }

        public string ProcessInput(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "Please type something. I'm here to help you stay safe online.";
            }

            // Step 1: Check if waiting for name
            if (_awaitingName)
            {
                _memory.Store("name", userInput);
                _awaitingName = false;
                return $"Nice to meet you, {_memory.UserName}! You can ask me about passwords, phishing, privacy, scams, or malware.";
            }

            // Step 2: Check for follow-up
            if (userInput.ToLower().Contains("tell me more") ||
                userInput.ToLower().Contains("explain more") ||
                userInput.ToLower().Contains("another tip"))
            {
                if (!string.IsNullOrEmpty(_lastTopic))
                {
                    string response = _keywords.GetResponse(_lastTopic);
                    return $"Here's another tip about {_lastTopic}: {response}";
                }
            }

            // Step 3: Detect sentiment
            Sentiment detectedSentiment = _sentiment.Detect(userInput);
            string sentimentResponse = string.Empty;

            if (detectedSentiment != Sentiment.Neutral)
            {
                sentimentResponse = _sentiment.GetSentimentResponse(detectedSentiment) + " ";
            }

            // Step 4: Check for memory/topic interest
            if (userInput.ToLower().Contains("interested in"))
            {
                string[] words = userInput.ToLower().Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == "in" && i + 1 < words.Length)
                    {
                        string topic = words[i + 1];
                        _memory.Store("topic", topic);
                        break;
                    }
                }
            }

            // Step 5: Get keyword response
            string keywordResponse = _keywords.GetResponse(userInput);

            if (keywordResponse != null)
            {
                foreach (var kw in _keywords.GetAllKeywords())
                {
                    if (userInput.ToLower().Contains(kw))
                    {
                        _lastTopic = kw;
                        break;
                    }
                }

                string personalised = _memory.GetPersonalisedOpener();
                return sentimentResponse + personalised + keywordResponse;
            }

            // Step 6: Special phrases
            if (userInput.ToLower().Contains("how are you"))
            {
                return "I'm functioning well, thank you! Ready to help you with cybersecurity questions.";
            }

            if (userInput.ToLower().Contains("what can you do") || userInput.ToLower().Contains("help"))
            {
                return "You can ask me about: passwords, phishing, privacy, scams, or malware.";
            }

            // Step 7: Fallback response
            return "I'm not sure I understand. Try asking about passwords, phishing, privacy, scams, or malware.";
        }
    }
}