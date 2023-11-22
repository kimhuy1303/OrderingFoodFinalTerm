

using OrderingFoodFinalTerm.DTO;

namespace OrderingFoodFinalTerm.Interface
{
    public interface IProductRepository
    {
        // lấy tất cả
        ICollection<Product> GetAll();
        // lấy data theo id
        Product GetById(int id);
        // thêm product
        ProductDTO Add(ProductDTO product);
        // sửa product
        void Update(ProductDTO product);
        // xóa product theo id
        void Delete(int id);

        void UpdateIsActive(int id, int status);
    }
}
