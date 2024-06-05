using Employee_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_API.Model;
using System;

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


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee([FromQuery] EmployeeDto searchDto)
        {
            var query = _context.Employees.AsQueryable();

            if (searchDto.EmpId.HasValue)
            {
                query = query.Where(e => e.EmpId == searchDto.EmpId.Value);
            }

            if (!string.IsNullOrEmpty(searchDto.EmpName))
            {
                query = query.Where(e => e.EmpName.Contains(searchDto.EmpName));
            }

            if (!string.IsNullOrEmpty(searchDto.DeptName))
            {
                query = query.Where(e => e.DeptName.Contains(searchDto.DeptName));
            }

            var searchEmployee = await query.ToListAsync();

            if (!searchEmployee.Any())
            {
                return NotFound("No employees found matching the search criteria.");
            }

            return Ok(searchEmployee);
        }




        /* [HttpGet("search")]
         public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee([FromQuery] EmployeeDto searchDto)
         {
             var query = _context.Employees.AsQueryable();

             switch (searchDto)
             {
                 case { EmpId: var empId } when empId.HasValue:
                     query = query.Where(e => e.EmpId == empId.Value);
                     break;
                 case { EmpName: var empName } when !string.IsNullOrEmpty(empName):
                     query = query.Where(e => e.EmpName.Contains(empName));
                     break;
                 case { DeptName: var deptName } when !string.IsNullOrEmpty(deptName):
                     query = query.Where(e => e.DeptName.Contains(deptName));
                     break;
                 case { Salary: var salary } when salary.HasValue:
                     query = query.Where(e => e.Salary == salary.Value);
                     break;
             }

             var searchEmployee = await query.ToListAsync();

             if (!searchEmployee.Any())
             {
                 return NotFound("No employees found matching the search criteria.");
             }

             return Ok(searchEmployee);
         }*/

        /*[HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee([FromQuery] EmployeeDto searchDto)
        {
            var query = _context.Employees.AsQueryable();

            if (searchDto.EmpId.HasValue)
            {
                query = query.Where(e => e.EmpId == searchDto.EmpId.Value);
            }
            else if (!string.IsNullOrEmpty(searchDto.EmpName))
            {
                query = query.Where(e => e.EmpName.Contains(searchDto.EmpName));
            }
            else if (!string.IsNullOrEmpty(searchDto.DeptName))
            {
                query = query.Where(e => e.DeptName.Contains(searchDto.DeptName));
            }
            else if (searchDto.Salary.HasValue)
            {
                query = query.Where(e => e.Salary == searchDto.Salary.Value);
            }

            var searchEmployee = await query.ToListAsync();

            if (!searchEmployee.Any())
            {
                return NotFound("No employees found matching the search criteria.");
            }

            return Ok(searchEmployee);
        }
*/



        [HttpPost("add")]
        public async Task<IActionResult> AddEmployeeDetails(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployees), new {id = employee.EmpId},employee);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployeeDetails(int id,Employee employee)
        {
            if(id != employee.EmpId) 
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
            return _context.Employees.Any( e => e.EmpId == id);
        }
    }
}
