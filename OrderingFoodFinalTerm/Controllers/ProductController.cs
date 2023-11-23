using Microsoft.AspNetCore.Mvc;
using OrderingFoodFinalTerm.Interface;
using OrderingFoodFinalTerm.Repository;
using OrderingFoodFinalTerm.DTO;

//using OrderingFoodFinalTerm.DTO;

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

        // Get All
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                return Ok(_productRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Get by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _productRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] ProductDTO product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            try
            {
                _productRepository.Update(product);
                return Ok("Update thành công");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //Update status isActive
        [HttpPut("updateStatus/{id}")]
        public IActionResult UpdateIsActive(int id, int status)
        {
            try
            {
                _productRepository.UpdateIsActive(id, status);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //Post
        [HttpPost]
        public IActionResult Add([FromForm] ProductDTO product)
        {
            try
            {
                var _product = _productRepository.GetAll()
                    .Where(c => c.ProductName.Trim().ToUpper() == product.ProductName.Trim().ToUpper())
                    .FirstOrDefault();
                // SP tồn tại
                if (_product != null)
                {
                    return BadRequest("Sản phẩm đã tồn tại");
                }
                _productRepository.Add(product);
                return Ok("Thêm thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
