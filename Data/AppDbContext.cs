using Microsoft.EntityFrameworkCore;
using APINEON.Models;

namespace APINEON.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RegisterShift> RegisterShifts { get; set; }
        public DbSet<ShiftAssignment> ShiftAssignments { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ánh xạ tên bảng (chữ thường)
            
            modelBuilder.Entity<Salary>().ToTable("salaries");
            modelBuilder.Entity<Shift>().ToTable("shifts");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<RegisterShift>().ToTable("registershifts");
            modelBuilder.Entity<ShiftAssignment>().ToTable("shiftassignments");
            modelBuilder.Entity<WorkLog>().ToTable("worklogs");

            // Cấu hình ràng buộc
            modelBuilder.Entity<User>()
                .HasCheckConstraint("check_role", "role IN ('manager', 'staff', 'admin')");

            modelBuilder.Entity<Shift>()
                .HasCheckConstraint("check_pay_multiplier", "PayMultiplier >= 0.5 AND PayMultiplier <= 3.0");

            modelBuilder.Entity<WorkLog>()
                .HasCheckConstraint("check_checkin_before_checkout", "CheckOut > CheckIn");

            // Cấu hình quan hệ
            modelBuilder.Entity<User>()
                .HasOne(u => u.salary)
                .WithMany()
                .HasForeignKey(u => u.salaryid);

            modelBuilder.Entity<RegisterShift>()
                .HasOne(rs => rs.User)
                .WithMany()
                .HasForeignKey(rs => rs.UserId);

            modelBuilder.Entity<RegisterShift>()
                .HasOne(rs => rs.Shift)
                .WithMany()
                .HasForeignKey(rs => rs.ShiftId);

            modelBuilder.Entity<RegisterShift>()
                .HasOne(rs => rs.DayOfWeek)
                .WithMany()
                .HasForeignKey(rs => rs.DayOfWeekId);

            modelBuilder.Entity<ShiftAssignment>()
                .HasOne(sa => sa.User)
                .WithMany()
                .HasForeignKey(sa => sa.UserId);

            modelBuilder.Entity<ShiftAssignment>()
                .HasOne(sa => sa.Shift)
                .WithMany()
                .HasForeignKey(sa => sa.ShiftId);

            modelBuilder.Entity<WorkLog>()
                .HasOne(wl => wl.User)
                .WithMany()
                .HasForeignKey(wl => wl.UserId);

            modelBuilder.Entity<WorkLog>()
                .HasOne(wl => wl.Shift)
                .WithMany()
                .HasForeignKey(wl => wl.ShiftId);
        }
    }
}