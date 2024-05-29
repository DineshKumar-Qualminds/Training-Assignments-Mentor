using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoutingInWebAPI.Data;
using RoutingInWebAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

     
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

       
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

      
        [HttpGet("byname/{name}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByName(string name)
        {
            var employees = await _context.Employees.Where(e => e.Name.Contains(name)).ToListAsync();

            if (employees == null || employees.Count == 0)
            {
                return NotFound();
            }

            return employees;
        }

    
        [HttpGet("bydepartment/{department}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDepartment(string department)
        {
            var employees = await _context.Employees.Where(e => e.Department == department).ToListAsync();

            if (employees == null || employees.Count == 0)
            {
                return NotFound();
            }

            return employees;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        
        

        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

      
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
