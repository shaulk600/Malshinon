using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Malshinon.Table_Pepole;

using MySql.Data.MySqlClient;

namespace Malshinon.DAL
{
    internal static class PepoleDAL
    {
        //Variable declaration
        public static MySqlConnection ObjToConnection;       
        public static string AccessDB = "server=127.0.0.1;user=root;password=;database=Malshinon"; // או זה
        public static string accDB = AcountToDB.GetInstance().GetPathDataBase(); // או זה

        //methods
        public static bool IsOpenConnection() => (ObjToConnection != null && ObjToConnection.State == System.Data.ConnectionState.Open);

        public static MySqlConnection openConnection()
        {
            if (ObjToConnection == null)
            {
                ObjToConnection = new MySqlConnection(AccessDB);
            }
            if (ObjToConnection.State != System.Data.ConnectionState.Open)
            {
                ObjToConnection.Open();
                Console.WriteLine("Connection successful...");
            }
            return ObjToConnection;
        }
        public static void closeConnection()
        {
            if (ObjToConnection != null && ObjToConnection.State == System.Data.ConnectionState.Open)
            {
                ObjToConnection.Close();
                ObjToConnection = null;
            }
        }

        public static int returnIdByFirstName(string firstName, string lastName)
        {
            
            //הגדרת משתנים
            int idPepole = -1;
            //!!!!!!!!!   המתודה הכי טובה להרצת SQL לא לשנות - בפקודה !!!
            try
            {
                using (var connection = new MySqlConnection(AccessDB))
                {
                    connection.Open();
                    string query = $"SELECT * FROM pepole WHERE first_name = '{firstName}'";
                    using (var cmd = new MySqlCommand(query, connection)) 
                    using (var reader = cmd.ExecuteReader())  // קורא
                    {
                        while (!reader.Read())
                        {
                            return idPepole;
                        }
                        idPepole = reader.GetInt32("Id_pepole");
                    }                
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
            return idPepole;
        }

        //import all data Pepole
        public static List<DBPepole> tablePepoleDataAll()
        {
            List<DBPepole> a;
            List<DBPepole> empty = new List<DBPepole>(1);
            try
            {
                using (MySqlConnection connectionA = new MySqlConnection(AccessDB))
                {
                    //string selecting = "SELECT * FROM Pepole";
                    using (var response = new MySqlCommand("SELECT * FROM Pepole", ObjToConnection))

                    using (var reader = response.ExecuteReader())// ואז תקלויט את הערכים ממה שכבר פתוח
                    {
                        a = new List<DBPepole>();
                        while (reader.Read())
                        {
                            int idPepole = reader.GetInt32("Id_pepole");
                            DBPepole temp = new DBPepole(idPepole);

                            temp.FirstName = reader.GetString("first_name") == null ? "" : Convert.ToString(reader.GetString("first_name"));
                            temp.LastName = reader.GetString("last_name") == null ? "" : Convert.ToString(reader.GetString("last_name"));
                            temp.SetSecretCode(reader.GetString("secret_code") == null ? "" : Convert.ToString(reader.GetString("secret_code")));
                            temp.SetTypePepole(reader.GetString("type_pepole") == null ? "" : Convert.ToString(reader.GetString("secret_code")));
                            temp.NumReports = reader.GetInt32("num_reports") == 0 ? 0 : Convert.ToInt32(reader.GetString("num_reports"));
                            temp.NumMentions = reader.GetInt32("num_mentions") == 0 ? 0 : Convert.ToInt32(reader.GetString("num_mentions"));

                            Console.WriteLine(temp.ReturningObjectString());
                            Console.WriteLine("");
                            a.Add(temp);
                        }
                        reader.Close();
                        return a;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching agents: {ex.Message}");
            }
            return empty;
        }


        //Exemple Code
        public static void testAll()
        {
            try
            {
                using (var connection = new MySqlConnection(AccessDB))
                {
                    connection.Open();
                    string query = $"SELECT last_name FROM pepole";
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())  // קורא
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
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
    }
}
