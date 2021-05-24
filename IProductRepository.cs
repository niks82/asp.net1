using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products_Microservice.Models;

namespace Products_Microservice.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int ProductId);
        //void InsertProduct(Product product);
        bool InsertProduct(int id, string name, string description, decimal price, byte categoryid);
        void DeleteProduct(int ProductId);
        //bool UpdateProduct(int id, string name, string description, decimal price, byte categoryid);
        bool UpdateProduct(Product product);
        void Save();
    }
}
