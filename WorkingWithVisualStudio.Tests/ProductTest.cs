using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void PriceTest()
        {
            //Arange
            Product prod = new Product { Name = "P1", Price = 50 };
            //Act
            prod.Price = 40;
            //Assert
            Assert.Equal(40, prod.Price);
        }
    }
}
