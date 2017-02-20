using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;
using WorkingWithVisualStudio.Controllers;
using Xunit;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void homeControllerTest() {
            //Arrange
            var controller = new HomeController();

            //Act
            var model = ((controller.Index()) as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Comparer<Product> c = new Comparer<Product>((p1, p2) => p1.Price == p2.Price && p1.Name == p2.Name);
            //Assert.Equal<Product>(SimpleRepository.SharedRepository.Products.Where(p=>p.Price<50), model, Comparer.Get((Product p1, Product p2) => p1.Name == p2.Name && p1.Price == p2.Price));
            Assert.Equal(SimpleRepository.SharedRepository.Products.Where(p=>p.Price<50),model, new Comparer<Product>((p1, p2) => p1.Price == p2.Price && p1.Name == p2.Name));

                }

        //new Product { Name="Kayak", Price=275M },
        //        new Product { Name = "Lifejacket", Price = 48.95M },
        //        new Product { Name = "Soccer ball", Price = 19.50M },
        //        new Product { Name = "Corner flag", Price = 34.95M }
        [Theory]
        [InlineData(50,48.95,19.5,34.95)]
        [InlineData(275, 48.95, 19.5, 34.95)]
        public void homeControllerTest2(decimal p1, decimal p2, decimal p3, decimal p4)
        {
            //Arrange
            HomeController controller = new HomeController();
            controller.Repository = new TestRepository(p1,p2,p3,p4);

            //Act
            var model = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Product>;

            //Assert
            Comparer<Product> comp = new Comparer<Product>((P1, P2) => P1.Price == P2.Price && P1.Name == P2.Name);
            Assert.Equal<Product>(controller.Repository.Products.Where(p=>p.Price<=50), model, comp);
        }

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void homeTest3(Product[] products)
        {
            //Arange
            var controller = new HomeController();
            controller.Repository = new TestRepository(products);

            //act
            var model = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(controller.Repository.Products.Where(p=>p.Price>0), model, new Comparer<Product>((p1, p2) => p1.Price == p2.Price && p1.Name == p2.Name));
        }

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void HomeTest4(Product[] products)
        {
            //Arrangecd
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
            as IEnumerable<Product>;
            // Assert
            Assert.Equal(controller.Repository.Products, model,
            Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
            && p1.Price == p2.Price));
        }
    }
}
