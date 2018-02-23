using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public static class StringExtensions
    {
        public static string Alphabetize(this String str)
        {
            char[] characters = str.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
