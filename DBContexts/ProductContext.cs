using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products_Microservice.Models;
using Products_Microservice.Repository;

namespace Products_Microservice.DBContexts
{
        public class ProductContext : DbContext
        {
            public ProductContext(DbContextOptions<ProductContext> options) : base(options)
            {
            }
            public DbSet<Product> Product { get; set; }
            public DbSet<Category> Categories { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        CategoryId = 1,
                        CategoryName = "Electronics",
                        CategoryDescription = "Electronic Items",
                    },
                    new Category
                    {
                        CategoryId = 2,
                        CategoryName = "Clothes",
                        CategoryDescription = "Dresses",
                    },
                    new Category
                    {
                        CategoryId = 3,
                        CategoryName = "Grocery",
                        CategoryDescription = "Grocery Items",
                    }
                );
            }

        public static implicit operator ProductContext(ProductRepository v)
        {
            throw new NotImplementedException();
        }
    }
    }

