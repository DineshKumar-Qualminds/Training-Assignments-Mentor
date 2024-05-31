using Employee_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_API.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> oprtions) : base(oprtions)
        {
        }

        public DbSet<Employee> Employees { get; set; }  
    }
}
