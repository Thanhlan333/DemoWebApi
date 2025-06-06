using System.ComponentModel.DataAnnotations;

namespace APINEON.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // VARCHAR(50) NOT NULL
        public TimeSpan StartTime { get; set; } // TIME NOT NULL
        public TimeSpan EndTime { get; set; } // TIME NOT NULL
        [Range(0.5, 3.0)]
        public decimal PayMultiplier { get; set; } = 1.0m; // NUMERIC(4, 2) NOT NULL DEFAULT 1.0
    }
}
