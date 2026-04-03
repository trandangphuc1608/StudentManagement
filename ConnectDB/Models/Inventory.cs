using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectDB.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // PK đồng thời là FK
        public int VariantId { get; set; }
        [ForeignKey("VariantId")]
        public Variant? Variant { get; set; }

        public int StockQuantity { get; set; }

        public int ReservedQuantity { get; set; }
    }
}