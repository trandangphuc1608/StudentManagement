using System.ComponentModel.DataAnnotations;

namespace ConnectDB.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string EventType { get; set; } = string.Empty;

        [StringLength(100)]
        public string EntityName { get; set; } = string.Empty;

        public int EntityId { get; set; }

        public string Changes { get; set; } = string.Empty;

        public int? UserId { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}