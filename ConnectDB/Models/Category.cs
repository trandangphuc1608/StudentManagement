using System.ComponentModel.DataAnnotations;

namespace ConnectDB.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}