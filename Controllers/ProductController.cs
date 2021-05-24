using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_Microservice.DBContexts;
using Products_Microservice.Models;
using Products_Microservice.Repository;

namespace Products_Microservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        public readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        //[Produces("application/json")]
        public IActionResult Get()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }


        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetProductByID(int id)
        {
            var product = _productRepository.GetProductByID(id);
            return new OkObjectResult(product);
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] Product product)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        _productRepository.InsertProduct(product.Id, product.Name, product.Description, product.Price, product.CategoryId);
        //        scope.Complete();
        //        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        //    }
        //}

        [HttpPost]
        public JsonResult Post(int id, string name, string description, decimal price, byte categoryid)
        {
            bool status = false;
            string message;
            try
            {
                status=_productRepository.InsertProduct(id, name, description, price, categoryid);
            if (status)
            {
                message = "Successful addition operation, ProductId = " + id;
            }
            else
            {
                message = "Unsuccessful addition operation!";
            }
        }
            catch (Exception ex)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);

}

        [HttpPut]
        public bool Put(Models.Product product)
        {
            bool status = false;

            try
            {
                if (ModelState.IsValid)
                {
                    Product prodObj = new Product();
                    prodObj.Id = product.Id;
                    prodObj.Name = product.Name;
                    prodObj.CategoryId = product.CategoryId;
                    prodObj.Price = product.Price;
                    prodObj.Description = product.Description;
                    status = _productRepository.UpdateProduct(prodObj);
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }


        //[HttpPut]
        //public IActionResult Put([FromBody] Product product)
        //{
        //    if (product != null)
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            _productRepository.UpdateProduct(product);
        //            scope.Complete();
        //            return new OkResult();
        //        }
        //    }
        //    return new NoContentResult();
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}
