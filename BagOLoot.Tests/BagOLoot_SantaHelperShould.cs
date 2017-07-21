using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class SantaHelperShould
    {
        SantaHelper _helper;

        public SantaHelperShould()
        {
            _helper = new SantaHelper();
        }

        [Fact]
        public void AddToyToChildsBag()
        {
            string toyName = "Skateboard";
            int childId = 2;
            string toy = _helper.AddToyToBag(toyName, childId);
            List<Toy> toys = _helper.GetChildsToys(childId);

            Assert.Equal(toyName, toy);
        }

        [Fact]
        public void RemoveToyFromBagShould()
        {
            int toyIdToRemove = 2;
            List<Toy> toys = _helper.RemoveToyFromBag(toyIdToRemove);
            List<int> toyIdList = new List<int>();
            foreach (Toy toy in toys)
            {
                toyIdList.Add(toy.id);
            }
            Assert.DoesNotContain(toyIdToRemove, toyIdList);
        }

        [Fact]
        public void GetChildsToysShould()
        {
            int childId = 2;
            List<Toy> toys = _helper.GetChildsToys(childId);
            Assert.IsType<List<Toy>>(toys);
        }

        [Fact]
        public void SetDeliveredStatusForChild() 
        {
            int childId = 715;
            bool deliveredStatus = _helper.SetDelivered(childId);

            Assert.Equal(deliveredStatus, true);
        }

    }
}