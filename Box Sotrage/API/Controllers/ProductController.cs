using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;
        private ProductValidator _productValidator;
        public ProductController(ProductRepository repository)
        {
            _productRepository = repository;
            _productValidator = new ProductValidator();
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpPost]
        public ActionResult CreateNewProduct(Product product)
        {
           var validation = _productValidator.Validate(product);
            if (validation.IsValid)
            {
                return Ok(_productRepository.InsertProduct(product));
            }
            return BadRequest(validation.ToString());
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            return Ok(_productRepository.DeleteProduct(product));
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var validation = _productValidator.Validate(product);
            if (validation.IsValid)
            {
                return Ok(_productRepository.EditProduct(product));
            }
            return BadRequest(validation.ToString());
        }

        [HttpGet("CreateDB")]
        public string CreateDB()
        {
            _productRepository.CreateDB();
            return "DataBase has been created";
        }


    }
}
