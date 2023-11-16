using System.ComponentModel.DataAnnotations;

namespace OrderingFoodFinalTerm
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? Firstname { get; set; }
        [MaxLength(50)]
        public string? Lastname { get; set; }
        [MaxLength(12)]
        public string? Phonenumber { get; set; }
        [MaxLength(50)]
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
    }
}
