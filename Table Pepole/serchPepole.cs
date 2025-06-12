using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Table_Pepole
{
    internal class serchPepole
    {
        private string PathDataBase = "";
        private string AccessDB = "server=127.0.0.1;user=root;password=;database=Malshinon";

      
        public void SearchByName(string name)
        {
            List<Dictionary<string, int>> data = new List<Dictionary<string, int>>();

            if (ImportData.IsOpen())
            {
                data = ImportData.DalSerch();
                int IdUpdate = SearchTheNameInList(data, name);
                if(IdUpdate == -1)
                {
                    //תעדכן חדש
                }
                else
                {
                    // תוסיף למקום של ...
                }
            }
        }
        


        private int SearchTheNameInList(List<Dictionary<string, int>> data , string name)
        {
            for(int i = 0; i<data.Count; i++)
            {
                if(data[i].Keys.Contains(name))
                {
                    string text = $"{data[i].Keys}";
                    if (text.Split('-')[0] == name)
                    {
                        int numberId = Convert.ToInt32(data[i].Values);
                        return numberId;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return -1;
        }
     
    }
}
