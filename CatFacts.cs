using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace ThmsRynr.CatFact
{
    public interface ICatFactService
    {
        public List<string> Facts { get; set; }
        public string GetFact();
    }

    public class CatFactService : ICatFactService
    {
        public List<string> Facts { get; set; }

        public CatFactService()
        {
            try
            {
                var factFile = Path.Combine(Environment.CurrentDirectory, "facts.txt");
                Facts = File.ReadAllLines(factFile).ToList();
            }
            catch (FileNotFoundException)
            {
                Facts = new List<string>() { "Didn't find any facts when we loaded up. Sorry about that." };
            }
        }

        public string GetFact()
        {
            var r = new Random();
            var fact = Facts[r.Next(0, Facts.Count)];
            return fact;
        }
    }
}