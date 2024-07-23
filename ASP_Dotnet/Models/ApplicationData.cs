using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SampleWebApp.Models
{
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; } //Path of the Image. 

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
        public int CompareTo(Product other)
        {
            return Name.CompareTo(other.Name);
        }
    }
    //DirectoryInfo.GetFiles, 
    public static class ApplicationData
    {
        public static HashSet<Product> CreateProducts(string dirName)
        {
            HashSet<Product> products = new HashSet<Product>();
            var files = Directory.GetFiles(dirName);
            Random random = new Random();
            int index = 0;
            foreach(var file in files)
            {
                var fileInfo = new FileInfo(file);
                var fileName = fileInfo.Name.Split('.')[0];
                var product = new Product();
                product.Name = fileName;
                product.Price = random.Next(50, 100);
                product.Image = $"\\Images\\{fileInfo.Name}";
                product.Id = ++index; 
                products.Add(product);
            }
            products.ToList().Sort();
            return products;
        }
        static ApplicationData()
        {
  //          AllProducts = createProducts(); 
            //AllProducts = new HashSet<Product>();
            //AllProducts.Add(new Product { Id = 1, Image = "\\Images\\apples.jpg", Name ="Apples", Price = 200 });
            //AllProducts.Add(new Product { Id = 2, Image = "\\Images\\Mangoes.jpg", Name ="Mangoes", Price = 230 });
            //AllProducts.Add(new Product { Id = 3, Image = "\\Images\\Oranges.jpg", Name ="Oranges", Price = 50 });
            //AllProducts.Add(new Product { Id = 4, Image = "\\Images\\pineapples.jpg", Name ="Pine Apples", Price = 30 });
            //AllProducts.Add(new Product { Id = 5, Image = "\\Images\\gauva.jpg", Name ="Gauva", Price = 60 });
            //AllProducts.Add(new Product { Id = 6, Image = "\\Images\\greenchillies.jpg", Name ="Green Chillies", Price = 140 });
            //AllProducts.Add(new Product { Id = 7, Image = "\\Images\\tomatoes.jpg", Name ="Tomatoes", Price = 50 });
            //AllProducts.Add(new Product { Id = 8, Image = "\\Images\\onions.jpg", Name ="Onions", Price = 35 });
            //AllProducts.Add(new Product { Id = 9, Image = "\\Images\\Potatoes.jpg", Name ="Potatoes", Price = 40 });
            //AllProducts.Add(new Product { Id = 10, Image = "\\Images\\brinjals.jpg", Name ="Brinjals", Price = 65 });
            //AllProducts.Add(new Product { Id = 11, Image = "\\Images\\Sonamasoori.jpg", Name ="Sona Masoori", Price = 55 });
            //AllProducts.Add(new Product { Id = 12, Image = "\\Images\\toordhal.jpg", Name ="Toor dhal", Price = 165 });
            //AllProducts.Add(new Product { Id = 13, Image = "\\Images\\bengalgram.jpg", Name ="Bengal Gram", Price = 120 });
            //AllProducts.Add(new Product { Id = 14, Image = "\\Images\\uladdhal.jpg", Name ="Ulad Dhal", Price = 110 });
            //AllProducts.Add(new Product { Id = 15, Image = "\\Images\\jaggery.jpg", Name ="Jaggery", Price = 130 });

        }
//        public static HashSet<Product> AllProducts { get; set; }
    }
}