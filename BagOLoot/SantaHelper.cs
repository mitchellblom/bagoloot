using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantaHelper
    {

        public int AddToyToBag(string toy, int child)
        {
            return 4;
        }

        public int RemoveToyFromBag(string toy, int child)
        {
            return 1;
        }

        public List<int> GetChildsToys(int childId)
        {
            return new List<int>() {4,6,7,8};
        }

    }

}