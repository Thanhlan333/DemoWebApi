using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINEON.Models
{
    public class User
    {
        public int id { get; set; } // INTEGER NOT NULL (SERIAL)
        public string fullname { get; set; } = string.Empty; // VARCHAR(100) NOT NULL
        public string phone { get; set; } = string.Empty; // VARCHAR(15) NOT NULL
        public string? email { get; set; } // VARCHAR(100)
        public string passwordhash { get; set; } = string.Empty; // VARCHAR(255) NOT NULL
        [RegularExpression("manager|staff|admin", ErrorMessage = "Role must be 'manager', 'staff', or 'admin'")]
        public string role { get; set; } = string.Empty; // VARCHAR(20) NOT NULL
        public string? gender { get; set; } // VARCHAR(10)
        public DateTime? dateofbirth { get; set; } // DATE
        public string? address { get; set; } // VARCHAR(255)
        public DateTime joindate { get; set; } = DateTime.UtcNow; // DATE DEFAULT CURRENT_DATE
        public string? branch { get; set; } // VARCHAR(100)
        public bool status { get; set; } = true; // BOOLEAN DEFAULT TRUE
        public int salaryid { get; set; } // INTEGER NOT NULL
        [ForeignKey("salaryid")] // Sửa "SalaryId" thành "salaryid" để khớp với tên thuộc tính
        public Salary salary { get; set; } = null!; // Navigation property
    }
}