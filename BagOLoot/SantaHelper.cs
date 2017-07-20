using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantaHelper
    {
        private List<string> _children = new List<string>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public SantaHelper()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public string AddToyToBag(string toy, int childId)
        {
            int _lastId = 0;
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = $"insert into toy values (null, '{toy}', {childId})";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        _lastId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }
                dbcmd.Dispose ();
                _connection.Close ();
            }
    
            string toyAdded = "Skateboard";
            return toyAdded;
        }

        public string RemoveToyFromBag(string toy, int childId)
        {
            return "removed";
        }

        public List<string> GetChildsToys(int childId)
        {
            return new List<string>() {"Skateboard", "Basketball"};
        }

        public bool SetDelivered(int childId)
        {
            return true;
        }

    }

}