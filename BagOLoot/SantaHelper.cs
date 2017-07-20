using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantaHelper
    {

        public string AddToyToBag(string toy, string child)
        {
            string toyAdded = "Skateboard";
            return toyAdded;
        }

        public string RemoveToyFromBag(string toy, string child)
        {
            return "removed";
        }

        public List<string> GetChildsToys(string toys)
        {
            return new List<string>() {"Skateboard", "Basketball"};
        }

        public bool SetDelivered(int childId)
        {
            return true;
        }

    }

}