using System.ComponentModel.DataAnnotations.Schema;

namespace APINEON.Models
{
    public class WorkLog
    {
        public int Id { get; set; }
        public int UserId { get; set; } // INTEGER NOT NULL
        public int ShiftId { get; set; } // INTEGER NOT NULL
        public DateTime WorkDate { get; set; } // DATE NOT NULL
        public DateTime CheckIn { get; set; } // TIMESTAMP NOT NULL
        public DateTime CheckOut { get; set; } // TIMESTAMP NOT NULL
        [ForeignKey("UserId")]
        public User User { get; set; } = null!; // Navigation property
        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; } = null!; // Navigation property
    }
}
