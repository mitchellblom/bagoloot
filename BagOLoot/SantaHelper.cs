using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantaHelper
    {

        public string AddToyToBag(string toy, int childId)
        {
    
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