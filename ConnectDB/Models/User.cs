using System.ComponentModel.DataAnnotations;

namespace ConnectDB.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string Roles { get; set; } = "Customer";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}