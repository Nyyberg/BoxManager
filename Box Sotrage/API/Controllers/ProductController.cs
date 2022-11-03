using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;
        public ProductController(ProductRepository repository)
        {
            _productRepository = repository;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpGet("CreateDB")]
        public string CreateDB()
        {
            _productRepository.CreateDB();
            return "DataBase has been created";
        }
    }
}
