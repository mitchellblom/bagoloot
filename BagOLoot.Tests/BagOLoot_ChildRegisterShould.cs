using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ChildRegisterShould
    {
        private readonly ChildRegister _register;

        public ChildRegisterShould()
        {
            _register = new ChildRegister();
        }

        [Fact]
        public void GetChildUsingChildId()
        {
            int childId = 2;
            var result = _register.GetChild(childId);
            Assert.IsType<string>(result);
        }

        [Theory]
        [InlineData("Sarah")]
        [InlineData("Jamal")]
        [InlineData("Kelly")]
        public void AddChildren(string child)
        {
            var result = _register.AddChild(child);
            Assert.True(result);
        }

        [Fact]
        public void ReturnListOfChildren()
        {
            var result = _register.GetChildren();
            Assert.IsType<List<string>>(result);
        }

        [Fact]
        public void ReturnListOfChildrenWhoWillGetToy()
        {
            var result = _register.GetChildrenWhoWillGetToy();
            Assert.IsType<List<string>>(result);
        }
        
    }
}