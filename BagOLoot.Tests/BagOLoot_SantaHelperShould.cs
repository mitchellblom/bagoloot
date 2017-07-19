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
            int childId = 715;
            int toyId = _helper.AddToyToBag(toyName, childId);
            List<int> toys = _helper.GetChildsToys(childId);

            Assert.Contains(toyId, toys);
        }

        [Fact]
        public void RemoveToyFromChildsBag()
        {
            string toyName = "Skateboard";
            int childId = 715;
            int toyId = _helper.RemoveToyFromBag(toyName, childId);
            List<int> toys = _helper.GetChildsToys(childId);

            Assert.DoesNotContain(toyId, toys);
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