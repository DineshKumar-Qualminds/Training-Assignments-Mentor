using Microsoft.EntityFrameworkCore;
using PaginationWebAPI.Model;

namespace PaginationWebAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<EmployeeDetails> EmployeesData { get; set; }
        
    }
}
