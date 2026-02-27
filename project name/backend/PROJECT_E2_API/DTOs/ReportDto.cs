namespace PROJECT_E2_API.DTOs
{
    // ek row darrojni attendance report maate
    public class DailyAttendanceReportDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PolicyName { get; set; } = string.Empty;
        public double MinDailyHours { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; } = string.Empty;  // Present 6 k Absent 6 k ShortHours
        public double HoursWorked { get; set; }
        public string DailyFlag { get; set; } = string.Empty;  // OK k pa6i PolicyViolation
    }
}