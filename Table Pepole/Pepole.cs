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
    }
}
