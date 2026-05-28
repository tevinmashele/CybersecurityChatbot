using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class MemoryStore
    {
        public string UserName { get; set; }
        public string FavouriteTopic { get; set; }

        private Dictionary<string, string> _customMemory;

        public MemoryStore()
        {
            _customMemory = new Dictionary<string, string>();
            UserName = string.Empty;
            FavouriteTopic = string.Empty;
        }

        public void Store(string key, string value)
        {
            if (key == "name")
                UserName = value;
            else if (key == "topic")
                FavouriteTopic = value;
            else
                _customMemory[key] = value;
        }

        public string Recall(string key)
        {
            if (key == "name")
                return UserName;
            else if (key == "topic")
                return FavouriteTopic;
            else if (_customMemory.ContainsKey(key))
                return _customMemory[key];

            return string.Empty;
        }

        public string GetPersonalisedOpener()
        {
            if (!string.IsNullOrEmpty(FavouriteTopic))
            {
                return $"As someone interested in {FavouriteTopic}, ";
            }
            return string.Empty;
        }
    }
}