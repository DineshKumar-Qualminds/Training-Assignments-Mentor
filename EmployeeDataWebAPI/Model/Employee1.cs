using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EmployeeDataWebAPI.Model
{
   
        public class Employee1
        {
            [Key]
            public int emp_id { get; set; }
            public string emp_name { get; set; }
            public string emp_lang { get; set; }
        }
    
}
