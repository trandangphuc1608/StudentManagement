using System.ComponentModel.DataAnnotations;

namespace ConnectDB.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public string? Source { get; set; }
        public string? Status { get; set; }
        public string? Owner { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}