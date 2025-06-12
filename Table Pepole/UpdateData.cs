//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MySql.Data.MySqlClient;

//using Malshinon;
////using Malshinon.Test;
//using Malshinon.Table_Pepole;
//using Malshinon.Menu;
//using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
//using System.Security.Cryptography.X509Certificates;

//namespace Malshinon.Table_Pepole
//{
//    internal static class UpdateData
//    {
//        public static MySqlConnection ObjToConnection;
//        public static string AccessDB = "server=127.0.0.1;user=root;password=;database=Malshinon";

       

//        public static MySqlConnection openConnection()
//        {
//            if (ObjToConnection == null)
//            {
//                ObjToConnection = new MySqlConnection(AccessDB);
//            }

//            if (ObjToConnection.State != System.Data.ConnectionState.Open)
//            {
//                ObjToConnection.Open();
//                Console.WriteLine("Connection successful.");
//            }

//            return ObjToConnection;
//        }//end open

//        public static void closeConnection()
//        {
//            if (ObjToConnection != null && ObjToConnection.State == System.Data.ConnectionState.Open)
//            {
//                ObjToConnection.Close();
//                ObjToConnection = null; //  מגדיר אותו בחזרה לnull
//            }
//        }

       

//        //public static void testu() // גיבוי של הקוד מלמעלה
//        //{
//        //    try
//        //    {
//        //        openConnection();

//        //        int rowsAffect;
//        //        string query = "INSERT INTO Pepole (first_name, last_name, secret_code , type_pepole, num_reports , num_mentions) VALUES ('@first_name', '@last_name' , '@secret_code ' , '@type_pepole' , @num_reports , @num_mentions)";

//        //        using (var cmd = new MySqlCommand(query, ObjToConnection))
//        //        {
//        //            cmd.Parameters.AddWithValue("@first_name ", pepole.FirstName);
//        //            cmd.Parameters.AddWithValue("@last_name", pepole.LastName);
//        //            cmd.Parameters.AddWithValue("@secret_code ", pepole.GetSecretCode());
//        //            cmd.Parameters.AddWithValue("@type_pepole", pepole.GetTypePepole());
//        //            cmd.Parameters.AddWithValue("@num_reports", pepole.NumReports);
//        //            cmd.Parameters.AddWithValue("@num_mentions", pepole.NumMentions);

//        //            cmd.CommandText = query;

//        //            cmd.ExecuteReader();
//        //            //rowsAffect = cmd.ExecuteNonQuery();
//        //            //Console.WriteLine($"{rowsAffect} rows inserted successfully");
//        //        }
//        //    }

//        //    catch (SqlException ex)
//        //    {
//        //            Console.WriteLine("MySQL Error: " + ex.Message);
//        //        }
//        //    catch (Exception ex)
//        //    {
//        //            Console.WriteLine("General Error: " + ex.Message);
//        //        }

//        //}        
//    }
//}
