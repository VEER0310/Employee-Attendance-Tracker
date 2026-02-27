namespace PROJECT_E2_API.DTOs
{
    public class CreateAttendanceDto
    {
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; } = string.Empty;  // "Present" chhe K "Absent"
        public double HoursWorked { get; set; }
    }
}