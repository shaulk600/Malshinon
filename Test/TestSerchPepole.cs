using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Malshinon;
using Malshinon.Table_Pepole;
using Malshinon.Menu;
using MySql.Data.MySqlClient;

namespace Malshinon.Test
{
    internal static class TestSerchPepole
    {
        public static void TestSearch()
        {
            //Guid pass = Guid.NewGuid();
            //string t = Convert.ToBase64String(pass.ToByteArray()).Substring(1,8);
            //Console.WriteLine(t);

            //SimpleReporting.findPerson("avram", "eee");

            //Console.WriteLine(PepoleDAL.returnIdByFirstName("avram", "eee"));

            //PepoleDAL.printerAll();

            DBPepole mm = new DBPepole(2);
            //mm.FirstName = "dfdegfv";
            //mm.LastName = "dekjgvsrf";
            //mm.TypePepole = "";
            //mm.NumReports = 1;
            //mm.NumMentions = 5;



            UpdateData.UpdatePlusValidation(mm);
        }
    }
}
