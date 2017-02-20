using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class FakeRepository
    {
        public static IEnumerable<Product> Products { get; set; }
        public FakeRepository(decimal p1, decimal p2, decimal p3, decimal p4)
        {
            Products = new Product[]
            {
                //new Product { Name="P1",Price=p1},
                //new Product { Name="P2",Price=p2},
                //new Product { Name="P3",Price=p3},
                //new Product { Name="P4",Price=p4}
                // new Product { Name="Kayak", Price=275M },
                //new Product { Name = "Lifejacket", Price = 48.95M },
                //new Product { Name = "Soccer ball", Price = 19.50M },
                //new Product { Name = "Corner flag", Price = 34.95M }
                 new Product { Name="Kayak", Price=p1 },
                new Product { Name = "Lifejacket", Price = p2 },
                new Product { Name = "Soccer ball", Price = p3 },
                new Product { Name = "Corner flag", Price = p4 }
            };
        }
    }

    public class TestRepository : IRepository
    {
        //private static TestRepository sharedRepository = new TestRepository();
        private Dictionary<string, Product> products
            = new Dictionary<string, Product>();

        //public static TestRepository SharedRepository => sharedRepository;
        public TestRepository(decimal p1, decimal p2, decimal p3, decimal p4)
        {
            var initialItems = new[]
            {
                new Product { Name="P1", Price=p1 },
                new Product { Name = "P2", Price = p2 },
                new Product { Name = "P3", Price = p3 },
                new Product { Name = "P4", Price = p4 }
            };
            foreach (var p in initialItems)
            {
                AddProduct(p);
            }
            //products.Add("Error", null);
        }

        public TestRepository(Product[] products)
        {
            foreach (var p in products)
            {
                AddProduct(p);
            }
        }
        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
