using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarHelperWebsite.Models
{
    public class Pattern
    {
        public string name { get; set; }
        public string pattern { get; set; }

        public Pattern(string name, string pattern)
        {
            this.name = name;
            this.pattern = pattern;
        }
    }
}
