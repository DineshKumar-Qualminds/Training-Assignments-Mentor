using System.ComponentModel.DataAnnotations;

namespace EmployeeDataWebAPI.Model
{
    public class Employee2
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_dept { get; set; }
        public int emp_salary { get; set; }
    }
}
