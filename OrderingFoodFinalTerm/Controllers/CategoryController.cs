using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingFoodFinalTerm.Interface;
using OrderingFoodFinalTerm.Repository;
using OrderingFoodFinalTerm.DTO;
using Microsoft.AspNetCore.Authorization;

namespace OrderingFoodFinalTerm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        // Get All
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                return Ok(_categoryRepository.GetAll());
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
                var data = _categoryRepository.GetById(id);
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
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Update(int id, [FromBody]CategoryDTO category)
        {
            if(category == null)
            {
                return BadRequest(ModelState);
            }
            if (id != category.Id)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _categoryRepository.Update(category);
                return NoContent();
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
                _categoryRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //Post
        [HttpPost]
        public IActionResult Add(CategoryDTO category)
        {
            try
            {
                var _category = _categoryRepository.GetAll()
                    .Where(c => c.CategoryName.Trim().ToUpper() == category.CategoryName.Trim().ToUpper())
                    .FirstOrDefault();
                // SP tồn tại
                if (_category != null)
                {
                    return BadRequest("Loại hàng đã tồn tại");
                }
                _categoryRepository.Add(category);
                return Ok("Thêm thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Search")]
        public IActionResult Search(string? key) 
        {
            try
            {
                var res = _categoryRepository.Search(key);
                return Ok(res);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
