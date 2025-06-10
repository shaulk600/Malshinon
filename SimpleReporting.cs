using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Table_Pepole;
using MySql.Data.MySqlClient;




namespace Malshinon
{
    internal static class SimpleReporting
    {

        public static int findPerson(string firstName, string lastName)
        {
            int idPepole = -1;
            string pathToSql = "server=localhost;user=root;password=;database=malshinon";

            try
            {
                using (var connection = new MySqlConnection(pathToSql))
                {
                    connection.Open();
                    string q = $"SELECT * FROM pepole WHERE first_name = '{firstName}'";
                    var cmd = new MySqlCommand(q, connection);
                    var reader = cmd.ExecuteReader();
                    //Console.WriteLine($"ok => {first_name}");
                    if ( ! reader.Read())
                    {
                        addPerson(firstName, lastName);
                    }
                    idPepole = reader.GetInt32("Id_pepole");
                }

                if (idPepole == -1) 
                { 
                    addPerson(firstName, lastName);
                    idPepole = findPerson(firstName, lastName);
                }
                Console.WriteLine("findPerson - end");
                return idPepole;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
                return idPepole;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return idPepole;
            }
            
            
        }

        public static void addPerson(string firstName, string lastName)
        {
            Guid g = Guid.NewGuid();
            string SecretCode = Convert.ToBase64String(g.ToByteArray()).Substring(1, 8);

            addPersonToDB(firstName, lastName, SecretCode);

            //DBPepole person = new DBPepole(firstName, lastName, SecretCode);
            Console.WriteLine("addPerson - end");

        }
        public static void addPersonToDB(string firstName, string lastName, string SecretCode)
        {
            string pathToSql = "server=127.0.0.1;user=root;password=;database=malshinon";

            try
            {
                //MySqlConnection connectionSql = new MySqlConnection(pathToSql); // מכיוון שאני יוצר אותו בתוכנית - מספיק לי היצירה - אם ארצה שיהיה קיים בקלאס נפרד צריך להגדיר אותו בכל סוף כ-NULL
                //if (connectionSql.State != System.Data.ConnectionState.Open)
                //{
                //    connectionSql.Open();
                //    Console.WriteLine("connectionSql - open");
                //}

                string typePepole = "reporter";
                int numReports = 0;
                int numMentions = 0;

                //צריך לשלוח אל וולידצייה
                using (var connection = new MySqlConnection(pathToSql))
                {
                    connection.Open();
                    string q = $"INSERT INTO pepole (first_name, last_name, secret_code, type_pepole, num_reports, num_mentions) VALUES ( '{firstName}', '{lastName}', '{SecretCode}', '{typePepole}', {numReports}, {numMentions})"; //רק אם אני שולח string אני חייב לשים גרשיים - באינט לא

                    var cmd = new MySqlCommand(q, connection);

                    cmd.ExecuteReader();
                    //var rowsAffect = cmd.ExecuteNonQuery();
                    //Console.WriteLine($"{rowsAffect} rows inserted successfully");
                }

                //string q = $"INSERT INTO Pepole (first_name, last_name, secret_code, type_pepole, num_reports, num_mentions) VALUES ('{firstName}', '{lastName}', '{typePepole}', {numReports}, {numMentions} )"; //רק אם אני שולח string אני חייב לשים גרשיים - באינט לא

                //var cmdA = new MySqlCommand(q, connectionSql);

                //int rowsAffectA = cmd.ExecuteNonQuery();
                //Console.WriteLine($"{rowsAffect} rows inserted successfully");
                //connectionSql.Close();
                //Console.WriteLine("connectionSql - close");

                Console.WriteLine("addPersonToDB - end");
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
    }
}
