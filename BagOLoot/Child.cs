using System;
using System.Collections.Generic;

namespace BagOLoot 
{
    public class Child
    {
        public int id;

        public string name;

        public int delivered;

        public Child(int id, string name, int delivered)
        {
            this.id = id;
            this.name = name;
            this.delivered = delivered;
        }
    }
}