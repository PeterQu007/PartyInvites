using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 275M
            };
            Product lifejacket = new Product
            {
                Name = "Lifejacket",
                Price = 48.95M
            };
            kayak.Related = lifejacket;
            return new Product[] { kayak, lifejacket, null };
        }
    }

    //public class ShoppingCart
    //{
    //    public IEnumerable<Product> Products { get; set; }
    //}

    public class ShoppingCart : IEnumerable<Product>
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static class MyExtensionMethods
    {
            //public static decimal TotalPrices(this ShoppingCart cartParam)
            //{
            //    decimal total = 0;
            //    foreach (Product prod in cartParam.Products)
            //    {
            //        total += prod?.Price ?? 0;
            //    }
            //    return total;
            //}

            public static decimal TotalPrices(this IEnumerable<Product> products)
            {
                decimal total = 0;
                foreach (Product prod in products)
                {
                    total += prod?.Price ?? 0;
                }
                return total;
            }

        public static IEnumerable<Product> FilterByPrice(
this IEnumerable<Product> productEnum, decimal minimumPrice)
        {
            foreach (Product prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }
    }
}
