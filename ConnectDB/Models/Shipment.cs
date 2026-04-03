using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectDB.Models
{
    public class Shipment
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [StringLength(100)]
        public string TrackingNumber { get; set; } = string.Empty;

        [StringLength(100)]
        public string Carrier { get; set; } = string.Empty;

        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
    }
}