using OrderingFoodFinalTerm.Interface;

namespace OrderingFoodFinalTerm.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainDbContext _context;
        public ProductRepository(MainDbContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetAllProducts() 
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }
    }
}
