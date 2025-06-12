using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using Malshinon;
//using Malshinon.Test;
//using Malshinon.Table_Pepole;
//using Malshinon.Menu;
using MySql.Data.MySqlClient;

namespace Malshinon.Table_Pepole
{
    internal class DBPepole
    {
        private int Id_Pepole;
        public string FirstName;
        public string LastName;
        private string SecretCode;
        private string TypePepole;
        public int NumReports;
        public int NumMentions;

         
        public DBPepole(int id_Pepole) 
        {
            Id_Pepole = id_Pepole;
        }

        public string GetSecretCode()
        {
            return SecretCode;
        }
        public void SetSecretCode(string value)
        {
            SecretCode = value;
        }

        public string GetTypePepole()
        {
            return TypePepole;
        }
        public void SetTypePepole(string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
                if ((value == "reporter" || value == "target" || value == "both" || value == "potential_agent"))
                {
                    this.TypePepole = value;
                }
                else
                {
                    this.TypePepole = "reporter";
                }
            }
            else
            {
                //this.TypePepole = "NULL";
                this.TypePepole = null;
            }   
        }

        public string ReturningObjectString()
        {
            return $"{FirstName},{LastName},{SecretCode},{TypePepole},{NumReports},{NumMentions}";
        }
        public string ReturningObjectToDataBase()
        {
            return $"'{FirstName}','{LastName}','{SecretCode}','{TypePepole}',{NumReports},{NumMentions}";
        }

    }

    public class PepoleToDB
    {
        public int Id_Pepole {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecretCode { get; set; }
        public string TypePepole { get; set; }
        public int NumReports { get; set; }
        public int NumMentions { get; set; }
    }
}
