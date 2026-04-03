using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectDB.Models
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [StringLength(50)]
        public string SKU { get; set; } = string.Empty;

        // Lưu JSON các thuộc tính (VD: {"Color": "Red", "Size": "M"})
        public string Attributes { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}