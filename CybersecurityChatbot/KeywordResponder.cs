using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        private Dictionary<string, List<string>> _responses;
        private Random _random;

        public KeywordResponder()
        {
            _random = new Random();
            _responses = new Dictionary<string, List<string>>();

            _responses.Add("password", new List<string>
            {
                "Use strong passwords with at least 12 characters including numbers and symbols.",
                "Never reuse the same password across multiple accounts.",
                "Enable Two-Factor Authentication (2FA) whenever possible.",
                "Use a password manager to store your passwords securely."
            });

            _responses.Add("phishing", new List<string>
            {
                "Never click on suspicious links in emails or SMS messages.",
                "Check the sender's email address carefully before responding.",
                "Look for spelling mistakes and urgent language - these are red flags.",
                "Hover over links to see the real URL before clicking."
            });

            _responses.Add("privacy", new List<string>
            {
                "Review your privacy settings on social media regularly.",
                "Limit the personal information you share online.",
                "Use a VPN when connecting to public Wi-Fi networks.",
                "Clear your browsing data and cookies regularly."
            });

            _responses.Add("scam", new List<string>
            {
                "If an offer sounds too good to be true, it probably is.",
                "Never send money or personal information to someone you haven't met.",
                "Scammers create urgency - take time to verify before acting.",
                "Report scams to the South African Banking Risk Information Centre."
            });

            _responses.Add("malware", new List<string>
            {
                "Keep your antivirus software updated at all times.",
                "Don't download attachments from unknown senders.",
                "Only install software from official websites.",
                "Run regular system scans to detect potential threats."
            });
        }

        public string GetResponse(string userInput)
        {
            userInput = userInput.ToLower();

            foreach (var keyword in _responses.Keys)
            {
                if (userInput.Contains(keyword))
                {
                    var responseList = _responses[keyword];
                    int index = _random.Next(responseList.Count);
                    return responseList[index];
                }
            }

            return null;
        }

        public List<string> GetAllKeywords()
        {
            return _responses.Keys.ToList();
        }
    }
}