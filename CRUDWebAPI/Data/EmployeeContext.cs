using Microsoft.EntityFrameworkCore;
using RoutingInWebAPI.Model;

namespace RoutingInWebAPI.Data
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
                : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }


    }
}
