using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Table_Pepole
{
    internal class Pepole
    {
        int IdPepole;
        string FirstName;
        string LastName;
        string SecretCode;
        string TypePepole;
        int NumReports;
        int NumMentions;

        
        public Pepole(int idPepole,string firstName,string lastName,string secretCode,string typePepole,int numReports,int numMentions)
        {
            IdPepole = idPepole;
            FirstName = firstName;
            LastName = lastName;
            SecretCode = secretCode;
            TypePepole = typePepole;
            NumReports = numReports;
            NumMentions = numMentions;
        }
        
        
        //אם צריך מתודה SELECT ALL DB
        public List<Pepole> DalSerch()
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

            //אולי פונקצייה אחרת- ואז נפנה אליה גם בתקלה וגם בלא
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();

            }
            return a;
        }
    }
}
