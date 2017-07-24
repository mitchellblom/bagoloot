using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ChildRegisterShould: IDisposable
    {
        private readonly ChildRegister _register;
        private readonly DatabaseInterface _db;

        // public ChildRegisterShould()
        // {
        //     _db = new DatabaseInterface("BAGOLOOT_TEST_DB");
        //     _register = new ChildRegister(_db);
        //     _db.CheckForChildTable();
        //     _db.CheckForToyTable();
        // }

        public ChildRegisterShould()
        {
            _register = new ChildRegister(_db);
        }

        [Theory]
        [InlineData("Unis")]
        [InlineData("Bert")]
        [InlineData("Fern")]
        public void AddChildren(string child)
        {
            var result = _register.AddChild(child);
            Assert.True(result);
        }

        [Fact]
        public void ReturnListOfChildren()
        {
            _register.AddChild("BabySpock");
            var result = _register.GetChildren();
            Assert.IsType<List<Child>>(result);
        }

        [Fact]
        public void ReturnListOfChildrenWhoWillGetToy()
        {
            var result = _register.GetChildrenWhoWillGetToy();
            Assert.IsType<List<string>>(result);
        }

        public void Dispose()
        {
            // _db.Delete("delete from child");
            // _db.Delete("delete from toy");
        }
        
    }
}