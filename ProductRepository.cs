using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products_Microservice.DBContexts;
using Products_Microservice.Models;

namespace Products_Microservice.Repository
{
    public class ProductRepository :IProductRepository

        {
            public readonly ProductContext _dbContext;

            public ProductRepository(ProductContext dbContext)
            {
                _dbContext = dbContext;
            }



        public void DeleteProduct(int productId)
            {
                var product = _dbContext.Product.Find(productId);
                _dbContext.Product.Remove(product);
                Save();
            }

            public Product GetProductByID(int productId)
            {
                return _dbContext.Product.Find(productId);
            }

            public IEnumerable<Product> GetProducts()
            {
                return _dbContext.Product.ToList();
            }

        public bool InsertProduct(int id, string name, string description, decimal price, byte categoryid)
        {
            bool status = false;
            try { 
            Product prodObj = new Product();
            
            prodObj.Id = id;
            prodObj.Name = name;
            prodObj.Description = description;
            prodObj.Price = price;
            prodObj.CategoryId = categoryid;
            _dbContext.Product.Add(prodObj);
            Save();
            status = true;
        }
            catch (Exception ex)
            {
                status = false;

            }
            return status;
        }

        //public void InsertProduct(Product product)
        //{

        //        _dbContext.Product.Add(product);
        //    Save();

        //}

        public void Save()
            {
            _dbContext.SaveChangesAsync();
            }

        public bool UpdateProduct(Product products)
        {
            bool status = false;
            try
            {
                var product = (from prdct in _dbContext.Product
                               where prdct.Id == products.Id
                               select prdct).FirstOrDefault<Product>();
                if (product != null)
                {
                    product.Id = products.Id;
                    product.Name = products.Name;
                    product.Description = products.Description;
                    product.Price = products.Price;
                    product.CategoryId = products.CategoryId;
                    _dbContext.SaveChanges();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        //public void UpdateProduct(Product product)
        //{ 
        //    _dbContext.Entry(product).State = EntityState.Modified;
        //    Save();
        //}
    }
    }

