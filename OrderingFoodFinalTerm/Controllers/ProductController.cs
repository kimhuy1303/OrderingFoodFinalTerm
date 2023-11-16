using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingFoodFinalTerm.DTO;
using OrderingFoodFinalTerm.Interface;

namespace OrderingFoodFinalTerm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts() 
        {
            var products = _productRepository.GetAllProducts();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(products);

        }
        
    }
}
