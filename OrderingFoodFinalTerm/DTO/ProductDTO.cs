namespace OrderingFoodFinalTerm.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
