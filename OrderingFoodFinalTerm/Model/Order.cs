using System.ComponentModel.DataAnnotations;

namespace OrderingFoodFinalTerm
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity {  get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
