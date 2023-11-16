using System.ComponentModel.DataAnnotations;

namespace OrderingFoodFinalTerm.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
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
    }
}
