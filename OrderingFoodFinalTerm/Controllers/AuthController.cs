using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingFoodFinalTerm.Interface;

namespace OrderingFoodFinalTerm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Register")]
        public ActionResult Register([FromBody] RegisterDTO request)
        {
            var checkExists = _userRepository.GetUserByName(request.Username);
            if(checkExists != null)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }
            if(request.Password != request.ConfirmPassword)
            {
                return BadRequest("Mật khẩu không trùng khớp");
            }
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var newUser = new UserDTO
            {
                Username = request.Username,
                Password = hashPassword,
            };
            var result = _userRepository.CreateUser(newUser);
            if (!result)
            {
                return BadRequest("Tạo tài khoản không thành công");
            }
            else
            {
                return Ok("Tạo thành công");
            }
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginDTO request)
        {
            var _user = _userRepository.GetUserByName(request.Username);
            if(_user == null || !_userRepository.ValidatePassword(_user, request.Password))
            {
                return BadRequest("Tài khoản hoặc mật khẩu không hợp lệ");
            }
            var token = _userRepository.CreateToken(_user);
            return Ok(new { Token = token });
        }
    }
}
