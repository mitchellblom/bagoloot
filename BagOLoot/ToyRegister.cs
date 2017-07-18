using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ToyRegister
    {
        // private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        // private SqliteConnection _connection;

        public string AddToy(string name)
        {
            return "Firetruck";
        }

        public string RemoveToy(string toyName, string childName)
        {
            // return Tuple<string, string>{"Firetruck", "Suzy"};
        }

    }
}