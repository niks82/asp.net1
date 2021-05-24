using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Microservice.Models
{
    public class Category
    {
        //public Category()
        //{
        //    Product = new HashSet<Product>();
        //}
        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        //public HashSet<Product> Product { get; }
    }
}
