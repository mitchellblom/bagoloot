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
            string childName = "Jamal";
            string toy = _helper.AddToyToBag(toyName, childName);
            List<string> toys = _helper.GetChildsToys(childName);

            Assert.Contains(toyName, toys);
        }

        [Fact]
        public void RemoveToyFromChildsBag()
        {
            string toyName = "Skateboard";
            string childName = "Jamal";
            string toy = _helper.RemoveToyFromBag(toyName, childName);
            List<string> toys = _helper.GetChildsToys(childName);

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