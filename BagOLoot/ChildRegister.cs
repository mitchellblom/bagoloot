using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ChildRegister
    {
        private List<string> _children = new List<string>();
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
                Console.WriteLine(dbcmd.CommandText);
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

        public string GetChild (int childId)
        {
            string _child = "";
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = $"select c.name from child c where c.id = {childId}";
                dbcmd.ExecuteNonQuery ();
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    while (dr.Read())
                    {
                        _child.Equals(dr[0].ToString());
                    }
                }
                dbcmd.Dispose ();
                _connection.Close ();
            }
            Console.WriteLine(_child);
            return _child;
        }

        public List<string> GetChildren ()
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = $"select name from child";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        _children.Add(dr[0].ToString());
                    }
                }
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