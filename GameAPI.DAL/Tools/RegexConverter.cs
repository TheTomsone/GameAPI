using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameAPI.DAL.Services
{
    public static partial class RegexConverter
    {
        [GeneratedRegex("[a-z]")]
        private static partial Regex RegexDeleteLowerChar();
        [GeneratedRegex("([a-z])([A-Z])")]
        private static partial Regex RegexUnderscoreBetweenLowerUpper();

        public static string UnderscoreBetweenLowerUpper(string str)
        {
            return RegexUnderscoreBetweenLowerUpper().Replace(str, "$1_$2");
        }
        public static string DeleteLowerChar(string str)
        {
            return RegexDeleteLowerChar().Replace(str, "");
        }
    }
}
