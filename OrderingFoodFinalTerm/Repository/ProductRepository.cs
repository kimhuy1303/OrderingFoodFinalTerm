using OrderingFoodFinalTerm.Interface;
using OrderingFoodFinalTerm.DTO;
using Microsoft.EntityFrameworkCore;

namespace OrderingFoodFinalTerm.Repository
{
    public class ProductRepository : IProductRepository

    {
        private readonly MainDbContext _context;

        public ProductRepository(MainDbContext context) 
        {
            _context = context;
        }
        //Add
        public ProductDTO Add(ProductDTO product)
        {
            var _product = new Product
            {
                ProductName = product.ProductName,
                ImagePath = product.ImagePath,
                Price = product.Price,
                Description = product.Description,
                IsActive = product.IsActive,
                CategoryId = product.CategoryId,
            };
            _context.Add(_product);
            _context.SaveChanges();
            return new ProductDTO
            {
                Id = _product.Id,
                ProductName = product.ProductName,
                ImagePath = product.ImagePath,
                Price = product.Price,
                Description = product.Description,
                IsActive = product.IsActive,
                CategoryId = product.CategoryId,
            };
        }


        public void Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if(product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
        }

        // Get all product
        public ICollection<Product> GetAll()
        {
            var products = _context.Products.Include(c => c.Category).ToList();
            return products;
        }

        // Get product by id
        public Product GetById(int id)
        {
            var product = _context.Products.Include(c => c.Category).SingleOrDefault(p => p.Id == id);
            if(product != null)
            {
                return product;
            }
            return null;
        }

        // Update product
        public void Update(ProductDTO product)
        {
            var _product = _context.Products.SingleOrDefault(p => p.Id == product.Id);
            _product.ProductName = product.ProductName;
            _product.Price = product.Price;
            _product.Description = product.Description;
            _product.IsActive = product.IsActive;
            _product.ImagePath = product.ImagePath;
            _product.CategoryId = product.CategoryId;
            _context.SaveChanges();
        }

        public void UpdateIsActive(int id, int status)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            product.IsActive = status;
            _context.SaveChanges();
            
        }
    }
}
