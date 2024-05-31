namespace WebAPIWithLINQ.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } // Navigation property for one-to-many relationship
    }
}
