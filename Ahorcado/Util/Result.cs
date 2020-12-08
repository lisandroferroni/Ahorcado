using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado.Util
{
    public class Result
    {
        public bool Success { get; set; }
        public string Value { get; set; }
        public string Info { get; set; }
    }
    public class ResultList
    {
        public bool Success { get; set; }
        public List<char> ValueList { get; set; }
        public string Info { get; set; }
    }

    
}
