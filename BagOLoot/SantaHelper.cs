using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantaHelper
    {
        private List<string> _children = new List<string>();
        private List<Toy> _toys = new List<Toy>();
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
            return toy;
        }

        public List<Toy> RemoveToyFromBag(int toyIdToRemove)
        {
            int _lastId = 0;
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = $"delete from toy where toy.id = {toyIdToRemove}";
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

            List<Toy> toyListAfterRemoval = new List<Toy>();
            return toyListAfterRemoval;
        }

        public List<Toy> GetChildsToys(int childId)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = $"select id, name, childId from toy where toy.childId = {childId};";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        _toys.Add(new Toy(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2)));
                    }
                }
                dbcmd.Dispose ();
                _connection.Close ();
            }
            return _toys;
        }

        public bool SetDelivered(int childId)
        {
            return true;
        }

    }

}