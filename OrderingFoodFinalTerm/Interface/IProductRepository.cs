namespace OrderingFoodFinalTerm.Interface
{
    public interface IProductRepository
    {
        ICollection<Product> GetAllProducts();
    }
}
