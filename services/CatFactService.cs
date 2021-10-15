using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace ThmsRynr.CatFact
{
    public class CatFactService : ICatFactService
    {
        public List<string> Facts { get; set; }
        private Random _random = new Random();

        public CatFactService()
        {
            try
            {
                var factFile = Path.Combine(Environment.CurrentDirectory, "facts.txt");
                Facts = File.ReadAllLines(factFile).ToList();
            }
            catch (FileNotFoundException)
            {
                Facts = new List<string>() { "I couldn't find any facts when I loaded up. Sorry about that." };
            }
        }

        public string GetFact()
        {
            var fact = Facts[_random.Next(0, Facts.Count)];
            return fact;
        }
    }
}