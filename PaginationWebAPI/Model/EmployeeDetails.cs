using System.ComponentModel.DataAnnotations;

namespace PaginationWebAPI.Model
{
    public class EmployeeDetails

    {
        [Key]
        public int EmpID { get; set; }

        [Required]
        public string EmpFname { get; set; }

        [Required]
        public string EmpLname { get; set; }

        [Required]
        public string Department { get; set; }

        public string Project { get; set; }

        public string Address { get; set; }

        [Required]
        public System.DateTime DOB { get; set; }

        public string Gender { get; set; }

        [Required]
        public string EmpPosition { get; set; }

        [Required]
        public System.DateTime DateOfJoining { get; set; }

        public decimal Salary { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


    }

}
