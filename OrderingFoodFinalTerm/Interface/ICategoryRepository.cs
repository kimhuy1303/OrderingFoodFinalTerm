using OrderingFoodFinalTerm.DTO;

namespace OrderingFoodFinalTerm.Interface
{
    public interface ICategoryRepository
    {
        // lấy tất cả
        ICollection<CategoryDTO> GetAll();
        // lấy data theo id
        CategoryDTO GetById(int id);
        // thêm product
        CategoryDTO Add(CategoryDTO category);
        // sửa product
        void Update(CategoryDTO category);
        // xóa product theo id
        void Delete(int id);
    }
}
