
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal static class AcountToDB
    {
        private static string PathDataBase;

        public static void UpdatePathDataBase(string value, string password)
        {
            if ((!string.IsNullOrEmpty(value)) && (!string.IsNullOrEmpty(password)))
            {
                if (password == "1234")
                {
                    AcountToDB.PathDataBase = value;
                }
            }
        }
        public static string GetPathDataBase()
        { return PathDataBase; }
    }
}

