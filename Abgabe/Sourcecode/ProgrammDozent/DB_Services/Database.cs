using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sybase.Data.AseClient;

namespace DB_Services
{
   
    public class Database
    {
        public string ConnectionString =  "Data Source=141.56.20.2;Port=5200;" +
                                    "UID=case04;PWD=itcyisay;" +
                                    "Database=case04;";

        readonly AseConnection _conn;
        public Database()
        {
           _conn = new AseConnection(ConnectionString);
        }

        public void Connect()
        {
            
            try
            {
                _conn.Open();
            }
            catch (AseException ex)
            {
                Console.Write(
                   ex.Message,
                   "Failed to connect");
            }
        }
        
        /// <summary>
        /// führt Datenbank-Abfrage aus
        /// </summary>
        /// <param name="query">Abfrage</param>
        /// <returns>Abfrageergebnis als Liste von Strings</returns>
        public List<string[]> ExecuteQuery(string query)
        {
            Connect();
            var strings = new List<string[]>();
            var command = new AseCommand(query, _conn);
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    var col = dataReader.FieldCount;
                    

                    while (dataReader.Read())
                    {
                        var array = new string[col];
                        for (var i = 0; i < col; i++)
                        {
                            array[i] = dataReader.GetString(i).Trim();
                        }
                        strings.Add(array);
                    }
                }
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(
                    "Es kann leider keine Verbindung zum Datenbank-Server augebaut werden. Bitte überprüfen Sie, ob Sie im Intranet sind, bzw. ob die VPN-Verbindung noch besteht.","Fehler");
                System.Environment.Exit(1);
            }

            _conn.Close();
            return strings;
        }
    }
}
