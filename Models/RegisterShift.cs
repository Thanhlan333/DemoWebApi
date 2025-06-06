using System.ComponentModel.DataAnnotations.Schema;

namespace APINEON.Models
{
    public class RegisterShift
    {
        public int Id { get; set; }
        public DateTime DateRegister { get; set; } // DATE NOT NULL
        public int UserId { get; set; } // INTEGER NOT NULL
        public int ShiftId { get; set; } // INTEGER NOT NULL
        public int DayOfWeekId { get; set; } // INTEGER NOT NULL
        [ForeignKey("UserId")]
        public User User { get; set; } = null!; // Navigation property
        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; } = null!; // Navigation property
        [ForeignKey("DayOfWeekId")]
        public DayWeek DayOfWeek { get; set; } = null!; // Navigation property
    }
}
