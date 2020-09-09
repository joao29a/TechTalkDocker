using System;
using System.Collections.Generic;

namespace SignalrServerWorker.Configurations
{
    public class UserConfiguration
    {
        public string Name { get; set; }
        public List<string> Sentences { get; set; }

        public string GetRandomSentence()
        {
            var random = new Random();
            var index = random.Next(Sentences.Count);
            return Sentences[index];
        }
    }
}
