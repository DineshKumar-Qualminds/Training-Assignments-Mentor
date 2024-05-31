using System.ComponentModel.DataAnnotations;

namespace Employee_API.Model
{
    public class Employee
    {
        [Key]
        public int emp_Id {  get; set; } 

        public string emp_Name { get; set; }  
        
        public string dept_Name { get; set; }   

        public  decimal salary { get; set; }    


    }
}
