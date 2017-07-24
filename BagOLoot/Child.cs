using System;
using System.Collections.Generic;

namespace BagOLoot 
{
    public class Child
    {
        private int _id;

        private string _name;

        private int _delivered;

        public int id
        {
            get 
            {
                return _id;
            }
        }

        public string name
        {
            get 
            {
                return _name;
            }
        }

        public int delivered
        {
            get 
            {
                return _delivered;
            }
        }

        public Child(int id, string name, int delivered)
        {
            this._id = id;
            this._name = name;
            this._delivered = delivered;
        }
    }
}