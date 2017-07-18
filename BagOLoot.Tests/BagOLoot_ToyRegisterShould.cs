using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ToyRegisterShould {
        private readonly ToyRegister _toyRegister;

        public ToyRegisterShould()
            {
                _toyRegister = new ToyRegister();
            }

        [Fact]
        public void RemoveToyFromChildShould()
        {
            var result = _toyRegister.RemoveToy("Firetruck", "Suzy");
            Assert.Equal(result, "Firetruck", "Suzy");
        }

    }
        
}