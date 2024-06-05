using System.ComponentModel.DataAnnotations;

namespace Employee_API.Model
{
    public class EmployeeDto
    {
        [Key]
        public int? EmpId { get; set; }

        public string? EmpName { get; set; }

        public string? DeptName { get; set; }

        public decimal? Salary { get; set; }
    }
}
