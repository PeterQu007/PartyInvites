using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace ClassLibrary1
{
    public class HomeControllerTests
    {
        class modelRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }
            public void AddProduct(Product p)
            {

            }
            //public modelRepository()
            //{
            //    Products = 
            //       new Product[] {
            //        //new Product { Name = "P1", Price = 275M },
            //        new Product { Name = "P2", Price = 48.95M },
            //        new Product { Name = "P3", Price = 19.50M },
            //        new Product { Name = "P3", Price = 34.95M }};
            //}
            }
        [Theory]
        [InlineData(275,48.95,19.50,34.95)]
        [InlineData(5,48.95,19.50,34.95)]
        public void IndexActionModelIsComplete(decimal price1,decimal price2,decimal price3,decimal price4)
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new modelRepository()
            {
                Products=new Product[]
                {
             
                    new Product { Name = "P1", Price = price1 },
                    new Product { Name = "P2", Price = price2 },
                    new Product { Name = "P3", Price = price3 },
                    new Product { Name = "P3", Price = price4 }}
        
            };
            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
            as IEnumerable<Product>;
            // Assert
            Assert.Equal(controller.Repository.Products , model,
            Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
            && p1.Price == p2.Price));
        }
    }
}