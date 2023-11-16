using System.ComponentModel.DataAnnotations;

namespace OrderingFoodFinalTerm
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Product> Products { get; set; }
    }
}
