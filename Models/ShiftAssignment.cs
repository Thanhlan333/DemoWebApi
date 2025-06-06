using System.ComponentModel.DataAnnotations.Schema;

namespace APINEON.Models
{
    public class ShiftAssignment
    {
        public int Id { get; set; }
        public int UserId { get; set; } // INTEGER NOT NULL
        public int ShiftId { get; set; } // INTEGER NOT NULL
        public DateTime WorkDate { get; set; } // DATE NOT NULL
        [ForeignKey("UserId")]
        public User User { get; set; } = null!; // Navigation property
        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; } = null!; // Navigation property
    }
}
