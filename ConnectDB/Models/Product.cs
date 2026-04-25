using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectDB.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MaxLength(200)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        // Bắt buộc phải có 2 dòng này thì C# mới không báo lỗi CS1061
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [ForeignKey("BrandId")]
        public Brand? Brand { get; set; }
    }
}