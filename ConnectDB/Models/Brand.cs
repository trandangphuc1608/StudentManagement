using System.ComponentModel.DataAnnotations;

namespace ConnectDB.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}