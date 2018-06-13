using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi3.ExtensionMethods
{
    public static class Utility
    {
        public static bool IsPari(this int n)
        {
            return n % 2 == 0;
        }

        public static bool IsCorrectFiscalCode(this string value)
        {
            return value.Length == 16;
        }

        public static bool IsCorrectFiscalCode(this string value, string country)
        {
            return value.Length == 16;
        }

        public static int GetBirthYear(this string value)
        {
            if (value.IsCorrectFiscalCode())
            {
                return Int32.Parse(value.Substring(6, 2));
            }
            else
            {
                return -1;
            }
        }

        public static bool IsBigMoreThan50K(this FileInfo file)
        {
            return file.Length > (50 * 1024);
        }
    }
}