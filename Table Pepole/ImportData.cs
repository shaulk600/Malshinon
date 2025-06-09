﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Malshinon.Table_Pepole
{
    internal static class ImportData
    {
        public static MySqlConnection ObjToConnection;
        public static string AccessDB = "server=127.0.0.1;user=root;password=;database=Malshinon";

        public static bool IsOpen()
        {
            try
            {
                openConnection();
                if (ObjToConnection != null && ObjToConnection.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message} - class ImportData");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message} - class ImportData");
            }
            return false;
        }

        public static MySqlConnection openConnection()
        {
            if (ObjToConnection == null)
            {
                ObjToConnection = new MySqlConnection(AccessDB);
            }

            if (ObjToConnection.State != System.Data.ConnectionState.Open)
            {
                ObjToConnection.Open();
                Console.WriteLine("Connection successful.");
            }

            return ObjToConnection;
        }//end open

        public static void closeConnection()
        {
            if (ObjToConnection != null && ObjToConnection.State == System.Data.ConnectionState.Open)
            {
                ObjToConnection.Close();
                ObjToConnection = null; //  מגדיר אותו בחזרה לnull
            }
        }
       
        public static List<Dictionary<string, int>> DalSerch()
        {
            //dictionary for firstName and LastName
            
            List<Dictionary < string, int> > toReturn = new List<Dictionary<string, int>>();
            
            MySqlCommand response = null;
            //אובייקט החזרת הערך 
            MySqlDataReader reader = null;

            try
            {
                openConnection();

                string selecting = "SELECT * FROM Pepole";
                response = new MySqlCommand(selecting, ObjToConnection);

                reader = response.ExecuteReader(); // ואז תקלויט את הערכים ממה שכבר פתוח  

                while (reader.Read())
                {
                    Dictionary<string, int> data = new Dictionary<string, int>();

                    int idPepole = reader.GetInt32("Id_pepole");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");

//vhhhhh
                    data.Add($"{firstName}-{lastName}", idPepole);
                    toReturn.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching agents: {ex.Message}");
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();

            }
            return toReturn;
        }


        public static List<Pepole> DalAll()
        {
            List<Pepole> a = new List<Pepole>();
            MySqlCommand response = null;
            //אובייקט החזרת הערך 
            MySqlDataReader reader = null;

            try
            {
                openConnection();

                string selecting = "SELECT * FROM Pepole";
                response = new MySqlCommand(selecting, ObjToConnection);

                reader = response.ExecuteReader(); // ואז תקלויט את הערכים ממה שכבר פתוח

                while (reader.Read())
                {
                    int idPepole = reader.GetInt32("Id_pepole");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    string secretCode = reader.GetString("secret_code");
                    string typePepole = reader.GetString("type_pepole");
                    int numReports = reader.GetInt32("num_reports");
                    int numMentions = reader.GetInt32("num_mentions");
                    Pepole temp = new Pepole(idPepole, firstName, lastName, secretCode, typePepole, numReports, numMentions);
                    a.Add(temp);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching agents: {ex.Message}");
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();
            }
            return a;
        }
        public void all()
        {

        }

    }
}
