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
            List<string> toys = _helper.GetChildsToys(childId);

            Assert.Equal(toyName, toy);
        }

        [Fact]
        public void RemoveToyFromBagShould()
        {
            string toyName = "Dollhouse";
            int childId = 2;
            List<string> toys = _helper.GetChildsToys(childId);
            Assert.DoesNotContain(toyName, toys);
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