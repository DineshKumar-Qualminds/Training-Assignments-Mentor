using Employee_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_API.Model;

namespace Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("get/{emp_Id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeById(int emp_Id)
        {
            var employee = await _context.Employees.FindAsync(emp_Id);

            if(employee == null) {

              return NotFound();    
            }
            return Ok(employee);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee(int? Id = null, string Name = null, string DepartmentName = null)
        {
            var query = _context.Employees.AsQueryable();

            if (Id.HasValue)
            {
                query = query.Where(e => e.emp_Id == Id.Value);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.emp_Name.Contains(Name));
            }

            if (!string.IsNullOrEmpty(DepartmentName))
            {
                query = query.Where(e => e.dept_Name.Contains(DepartmentName));
            }

            var searchEmployee = await query.ToListAsync();

            if (!searchEmployee.Any())
            {
                return NotFound("No employees found matching the search criteria.");
            }

            return Ok(searchEmployee);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddEmployeeDetails(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployees), new {id = employee.emp_Id},employee);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployeeDetails(int id,Employee employee)
        {
            if(id != employee.emp_Id) 
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException)
            {
               if(!EmployeeExits(id))
                {
                    return NotFound();  
                }
                else
                {
                    throw;
                }
            }
            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDetails(int id)
        {
            var employee = await _context.Employees.FindAsync();

            if(employee == null) 
            { 
                return NotFound();
            }
            _context.Employees.Remove(employee);    
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EmployeeExits(int id)
        {
            return _context.Employees.Any( e => e.emp_Id == id);
        }
    }
}
