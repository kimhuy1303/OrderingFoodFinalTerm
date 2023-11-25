using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingFoodFinalTerm.DTO;
using OrderingFoodFinalTerm.Interface;
using OrderingFoodFinalTerm.Repository;

namespace OrderingFoodFinalTerm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // Get All
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_menuRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //Get By Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _menuRepository.GetById(id);
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
        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _menuRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(MenuDTO menu)
        {
            try 
            {
                _menuRepository.Add(menu);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPost("Product")]
        public IActionResult AddProduct(MenuProductDTO request)
        {
            try
            {
                // Nếu không có menu id 
                if (_menuRepository.CheckExistMenu(request.MenuId) == false)
                {
                    return NotFound("Id Menu không tìm thấy");
                }
                // lấy id của menu mình tìm, tham chiếu đến list product trong menu,
                // nếu id truyền vào = id product => true
                var product = _menuRepository.GetById(request.MenuId)
                              .Products.Any(c => c.Id == request.ProductId);
                if (product)
                {
                    return BadRequest("Sản phẩm này tồn tại");
                }

                _menuRepository.AddProduct(request);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpDelete("Product")]
        public IActionResult DeleteProduct(MenuProductDTO request)
        {
            try
            {
                // Nếu không có menu id 
                if (_menuRepository.CheckExistMenu(request.MenuId) == false)
                {
                    return NotFound("Id Menu không tìm thấy");
                }
                // lấy id của menu mình tìm, tham chiếu đến list product trong menu,                
                // nếu id truyền vào = id product => true
                var product = _menuRepository.GetById(request.MenuId)
                              .Products.Any(c => c.Id == request.ProductId);
                if (product)
                {
                    _menuRepository.RemoveProduct(request);
                    return Ok("Xóa thành công");
                }
                return BadRequest("Không tìm thấy sản phẩm");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(MenuDTO menu, int id)
        {

            if (id != menu.Id)
            {
                return BadRequest("Không tìm thấy Id menu");
            }
            try
            {
                _menuRepository.Update(menu);
                return Ok("Update thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
        }
    }
}
