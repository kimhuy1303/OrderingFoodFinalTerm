using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingFoodFinalTerm.Interface;
using OrderingFoodFinalTerm.Repository;
using System.Linq.Expressions;

namespace OrderingFoodFinalTerm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            try
            {
               _orderRepository.CreateOrder(order);
                return Ok("Tạo mới đơn hàng thành công");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public IActionResult OrderDetail(int orderId) 
        { 

            try
            {
                var orderDetail =  _orderRepository.GetOrderByID(orderId);
                return Ok(orderDetail);
            }
            catch
            {
                return NotFound("Khong tim thay id");
            }
        }

        [HttpGet]
        public IActionResult GetAllOrder()
        {
            try
            {
                return Ok(_orderRepository.GetAll());
            }
            catch {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



    }
}
