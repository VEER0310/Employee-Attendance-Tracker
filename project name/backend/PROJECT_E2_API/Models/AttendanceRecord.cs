
namespace PROJECT_E2_API.Models
{
    public class AttendanceRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; } = string.Empty;  // Present / Absent / ShortHours
        public double HoursWorked { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}