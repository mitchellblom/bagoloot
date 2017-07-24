using System;
using System.Collections.Generic;

namespace BagOLoot 
{
    public class Toy
    {
        private int _id;

        private string _name;

        private int _childId;

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
        public int childId
        {
            get 
            {
                return _childId;
            }
        }

        public Toy(int id, string name, int childId)
        {
            this._id = id;
            this._name = name;
            this._childId = childId;
        }
    }
}