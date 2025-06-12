
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malshinon.DAL;

namespace Malshinon
{
    internal class AcountToDB
    {
        /// <summary>
        /// The class 'AccountToDB' is intended to provide a path to the database in order to retrieve data from it - it is not a static class.
        /// The department is complete.
        /// </summary>

        //Variable declaration
        private string PathDataBase;
        private static AcountToDB instance = null;

        //constructor Private
        private AcountToDB() {  }
        // real constractor
        public static AcountToDB GetInstance()
        {
            if (instance == null)
            {
                instance = new AcountToDB();
            }
            return instance;
        }


        //methods

        /// <summary>
        /// The function should insert or update the path when accessing the DataBase
        /// </summary>
        /// <param name="value"></param>
        /// <param name="password"></param>
        public void UpdatePathDataBase(string value, string password)
        {
            bool f = true;
            while (f || (value != "" && password != "") )
            {
                if ((!string.IsNullOrEmpty(value)) && (!string.IsNullOrEmpty(password)))
                {
                    if (password == "1234")
                    {
                        //AcountToDB.PathDataBase = value; // אפשר לכתוב כך ואפשר כך
                        if (value.Contains("server="))
                        {
                            this.PathDataBase = $"server=127.0.0.1;user=root;password=;database={value}";
                        }
                        else
                        {
                            this.PathDataBase = value;                           
                        }
                        f = false;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a path value and password to access the system.");
                }
            }
        }

        /// <summary>
        /// The function is supposed to return the path of the database in the project.
        /// If no value was entered initially, the value returned will be "".
        /// </summary>
        /// <returns>String Path</returns>
        //במקום לכתוב return או לשאול האם זה null אפשר לכתוב ככה
        public string GetPathDataBase() => string.IsNullOrEmpty(PathDataBase) ? "" : PathDataBase;

    }
}

