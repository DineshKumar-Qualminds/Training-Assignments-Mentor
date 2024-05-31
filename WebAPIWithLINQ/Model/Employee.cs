﻿namespace WebAPIWithLINQ.Model
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } // Navigation property for Department relationship
    }
}
