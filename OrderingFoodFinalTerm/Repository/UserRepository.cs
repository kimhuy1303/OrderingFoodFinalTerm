using OrderingFoodFinalTerm.Interface;

namespace OrderingFoodFinalTerm.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _context;

        public UserRepository(MainDbContext context)
        {
            _context = context;
        }

        public User GetUserById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(e => e.Id == id);
            return user;
        }
    }
}
