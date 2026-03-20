using System.ComponentModel.DataAnnotations;

namespace ConnectDB.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string TeacherCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(100)]
        public string Department { get; set; } = string.Empty;
    }
}