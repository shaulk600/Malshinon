using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //צריך גם את זה

using Malshinon.Table_Pepole;
using MySql.Data.MySqlClient; // וגם את זה




namespace Malshinon
{
    internal static class SimpleReporting
    {

        public static void findPerson(string firstName, string lastName)
        {
            
            string pathToSql = "server=localhost;user=root;password=;database=malshinon";
            //string pathToSql = AcountToDB.GetPathDataBase();

            try
            {
                using (var connection = new MySqlConnection(pathToSql))
                {
                    connection.Open();
                    string q = $"SELECT * FROM pepole WHERE first_name = '{firstName}'";
                    var cmd = new MySqlCommand(q, connection);
                    
                    //שולח לאימות נתונים מול database
                    DBNameCheck(firstName, lastName, cmd);    
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                
            } 
        }

        public static void DBNameCheck(string firstName, string lastName, MySqlCommand cmd)
        {
            var reader = cmd.ExecuteReader();
            //שלב החלוקה 
            if (!reader.Read())
            {
                addPerson(firstName, lastName);
                findPerson(firstName, lastName);
                return;
            }
            else
            {
                //יצירת אובייקט לנדידת נתונים 
                DBPepole personCurrect = new DBPepole(reader.GetInt32("Id_pepole"));
                //personCurrect.Id_Pepole = reader.GetInt32("Id_pepole");
                personCurrect.FirstName = reader.GetString("first_name");
                personCurrect.LastName = reader.GetString("last_name");
                //personCurrect.SecretCode = reader.GetString("secret_code");
                personCurrect.SetSecretCode( reader.GetString("secret_code"));
                //personCurrect.TypePepole = reader.GetString("type_pepole");
                personCurrect.SetTypePepole(reader.GetString("type_pepole"));
                personCurrect.NumReports = reader.GetInt32("num_reports");
                personCurrect.NumMentions = reader.GetInt32("num_mentions");
                return;
            }
        }

        public static void addPerson(string firstName, string lastName)
        {
            Guid g = Guid.NewGuid();
            string SecretCode = Convert.ToBase64String(g.ToByteArray()).Substring(1, 8);

            Console.WriteLine("addPerson - end ");
            addPersonToDB(firstName, lastName, SecretCode);

        }

        public static void addPersonToDB(string firstName, string lastName, string SecretCode)
        {
            string pathToSql = "server=127.0.0.1;user=root;password=;database=malshinon";
            //string pathToSql = AcountToDB.GetPathDataBase();

            try
            {
                string typePepole = "reporter";
                int numReports = 0;
                int numMentions = 0;

                //צריך לשלוח אל וולידציה - ליצור מתודת וולידציה 
                using (var connection = new MySqlConnection(pathToSql))
                {
                    connection.Open();
                    string q = $"INSERT INTO pepole (first_name, last_name, secret_code, type_pepole, num_reports, num_mentions) VALUES ( '{firstName}', '{lastName}', '{SecretCode}', '{typePepole}', {numReports}, {numMentions})"; //רק אם אני שולח string אני חייב לשים גרשיים - באינט לא

                    var cmd = new MySqlCommand(q, connection);

                    cmd.ExecuteReader();
                }
                Console.WriteLine("addPersonToDB - end");
                
                //צריך ליצור דיווח
                // class login
                Console.WriteLine("a- create LogIN");
            }

            catch (SqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
                Console.WriteLine("NOT Create in Table pepole - Check value to DataBase");
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                Console.WriteLine("NOT Create in Table Pepole - Check if value is not empty");
            }
        }

        public static void AddingPointsIsPepole(DBPepole p , string size = "T")
        {
            if(size.Contains("R"))
            {
                ++p.NumReports;
            }
            if (size.Contains("T"))
            {
                ++p.NumMentions;
            }
        }
    }
}
