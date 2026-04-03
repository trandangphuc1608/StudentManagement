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
    }
}