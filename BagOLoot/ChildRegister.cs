using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ChildRegister
    {
        private List<Child> _children = new List<Child>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ChildRegister()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public bool AddChild (string child) 
        {
            int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                dbcmd.CommandText = $"insert into child values (null, '{child}', 0)";
                dbcmd.ExecuteNonQuery ();

                // Get the id of the new row
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
            return _lastId != 0;
        }

        public List<Child> GetChildren ()
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = "select name from toy where toy.childId = {}";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        _children.Add(new Child(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2)));
                    }
                }
                Console.WriteLine($"_children = {_children.Count}");
                dbcmd.Dispose ();
                _connection.Close ();
            }
            return _children;
        }

        public List<string> GetChildrenWhoWillGetToy ()
        {
            return new List<string>();
        }

    }
}