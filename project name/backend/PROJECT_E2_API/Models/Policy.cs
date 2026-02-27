
namespace PROJECT_E2_API.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double MinDailyHours { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}