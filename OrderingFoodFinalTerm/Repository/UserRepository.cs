using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderingFoodFinalTerm.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace OrderingFoodFinalTerm.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(MainDbContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        public bool CreateUser(UserDTO request)
        {
            var _user = new User
            {
                Username = request.Username,
                Password = request.Password,
                CreatedDate = request.CreatedDate,
                RoleId = request.RoleId,
            };
            _context.Add(_user);
            var res = _context.SaveChanges();
            return res > 0 ;
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Where(e => e.Id == id).Include(e => e.Role).FirstOrDefault();
            return user;
        }

        public User GetUserByName(string name)
        {
            var user = _context.Users.Where(e => e.Username == name).Include(e => e.Role).FirstOrDefault();
            return user;
        }

        public bool ValidatePassword(User user, string password)
        {
            
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Rolename)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
