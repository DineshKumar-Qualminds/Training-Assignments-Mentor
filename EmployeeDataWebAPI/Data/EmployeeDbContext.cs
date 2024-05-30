using EmployeeDataWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeDataWebAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee1> Employees1 { get; set; }
        public DbSet<Employee2> Employees2 { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee1>().HasData(
                new Employee1() { emp_id = 300, emp_name = "Anu", emp_lang = "C#" },
                new Employee1() { emp_id = 301, emp_name = "Mohit", emp_lang = "C" },
                new Employee1() { emp_id = 302, emp_name = "Sona", emp_lang = "Java" },
                new Employee1() { emp_id = 303, emp_name = "Lana", emp_lang = "Java" },
                new Employee1() { emp_id = 304, emp_name = "Lion", emp_lang = "C#" },
                new Employee1() { emp_id = 305, emp_name = "Ramona", emp_lang = "Java" }
            );

            modelBuilder.Entity<Employee2>().HasData(
                new Employee2() { emp_id = 300, emp_dept = "Designing", emp_salary = 23000 },
                new Employee2() { emp_id = 301, emp_dept = "Developing", emp_salary = 40000 },
                new Employee2() { emp_id = 302, emp_dept = "HR", emp_salary = 50000 },
                new Employee2() { emp_id = 303, emp_dept = "Designing", emp_salary = 60000 },
                new Employee2() { emp_id = 403, emp_dept = "Production", emp_salary = 50000 }
            );
        }
    }
}
