using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingFoodFinalTerm.DTO;
using OrderingFoodFinalTerm.Interface;
using OrderingFoodFinalTerm.Repository;

namespace OrderingFoodFinalTerm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ICartRepository _cartRepository;


        public CartController(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        [HttpPost("Item")]
        public IActionResult AddItemToCart(int productId, int userId, int quantity = 1)
        {
            try
            {
                _cartRepository.AddProduct(productId, userId, quantity);
                return Ok("Thêm thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var cartItem = _cartRepository.GetCartItemById(id);
                return Ok(cartItem);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("CartItem")]
        public IActionResult Remove(int userId, int cartItemId)
        {
            var cart = _cartRepository.getCartByUserId(userId);
            if (cart != null)
            {
                _cartRepository.removeCartItem(cartItemId);
                return Ok("Xóa thành công");
            }
            return BadRequest();
        }
        [HttpPut("QuantityCartItem")]
        public IActionResult EditQuantityProduct(int userId, int cartProductId, int quantity)
        {
            var cart = _cartRepository.getCartByUserId(userId);
            if (cart != null)
            {
                _cartRepository.EditQuantityProduct(cartProductId, quantity);
                return Ok("chỉnh số lượng thành công");
            }
            return BadRequest();
        }

        [HttpPost("Checkout")]
        public void CheckOut(int userId, OrderDTO order)
        {
            var cart = _cartRepository.getCartByUserId(userId);
            if (cart != null && cart.CartItems.Any())
            {
                var _order = new Order
                {
                    UserId = userId,
                    CreatedDate = DateTime.Now,
                    CustomerAddress = order.CustomerAddress,
                    CustomerName = order.CustomerName,
                    CustomerPhone = order.CustomerPhone,
                    TotalPrice = cart.CartItems.Sum(x => x.TotalPrice)
                };
              
                _orderRepository.CreateOrder(_order);

                _orderRepository.SaveChange();
                _cartRepository.SaveChange();
            }
        }
    }

}
