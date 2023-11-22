using System.ComponentModel.DataAnnotations;

namespace OrderingFoodFinalTerm
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public List<Product> Products { get; set;}
    }
}
