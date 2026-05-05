using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectDB.Models
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; } = string.Empty;

        [StringLength(20)]
        public string DiscountType { get; set; } = "percent";

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountValue { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int UsageLimit { get; set; }
        public int Quantity { get; set; } // Số lượng mã còn lại
        public double DiscountPercent { get; set; } // Phần trăm giảm (VD: 10, 20)
        public double? MaxDiscountAmount { get; set; } // Giảm tối đa (Có dấu ? để cho phép Null nếu không giới hạn)
    }
}