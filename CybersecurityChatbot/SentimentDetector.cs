using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated,
        Happy
    }

    public class SentimentDetector
    {
        private Dictionary<Sentiment, List<string>> _triggerWords;
        private Dictionary<Sentiment, string> _empatheticResponses;

        public SentimentDetector()
        {
            _triggerWords = new Dictionary<Sentiment, List<string>>();
            _empatheticResponses = new Dictionary<Sentiment, string>();

            _triggerWords.Add(Sentiment.Worried, new List<string>
            {
                "worried", "scared", "afraid", "anxious", "nervous", "unsafe", "concerned"
            });
            _empatheticResponses.Add(Sentiment.Worried,
                "I understand your concern. Let me help you stay safe.");

            _triggerWords.Add(Sentiment.Curious, new List<string>
            {
                "curious", "wondering", "interested", "want to know", "how does", "explain"
            });
            _empatheticResponses.Add(Sentiment.Curious,
                "That's a great question. I'm glad you're taking an interest.");

            _triggerWords.Add(Sentiment.Frustrated, new List<string>
            {
                "frustrated", "annoyed", "confused", "don't understand", "too complicated"
            });
            _empatheticResponses.Add(Sentiment.Frustrated,
                "I know this can be confusing. Let me simplify it for you.");

            _triggerWords.Add(Sentiment.Happy, new List<string>
            {
                "great", "thanks", "helpful", "awesome", "love it", "appreciate"
            });
            _empatheticResponses.Add(Sentiment.Happy,
                "You're welcome! I'm happy to help.");
        }

        public Sentiment Detect(string userInput)
        {
            userInput = userInput.ToLower();

            foreach (var sentiment in _triggerWords)
            {
                foreach (var word in sentiment.Value)
                {
                    if (userInput.Contains(word))
                    {
                        return sentiment.Key;
                    }
                }
            }

            return Sentiment.Neutral;
        }

        public string GetSentimentResponse(Sentiment sentiment)
        {
            if (_empatheticResponses.ContainsKey(sentiment))
            {
                return _empatheticResponses[sentiment];
            }
            return string.Empty;
        }
    }
}