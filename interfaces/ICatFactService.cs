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
}