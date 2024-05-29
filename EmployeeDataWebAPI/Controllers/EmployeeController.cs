using EmployeeDataWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDataWebAPI.Controllers
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

        //1.Get the common employee data from two tables
        [HttpGet("common")]
        public async Task<IActionResult> GetCommonEmployees()
        {
            var commonEmployees = await (from e1 in _context.Employees1
                                         join e2 in _context.Employees2 on e1.emp_id equals e2.emp_id
                                         select new { e1.emp_id, e1.emp_name, e1.emp_lang, e2.emp_dept, e2.emp_salary }).ToListAsync();

            return Ok(commonEmployees);
        }

        //2. Get employee data who are not present in table1
        [HttpGet("notintable1")]
        public async Task<IActionResult> GetNotInTable1()
        {
            var notInTable1 = await (from e2 in _context.Employees2
                                     where !_context.Employees1.Any(e1 => e1.emp_id == e2.emp_id)
                                     select e2).ToListAsync();

            return Ok(notInTable1);
        }

        // 3. Get the emp info who are in the Designing and HR department
        [HttpGet("designing_hr")]
        public async Task<IActionResult> GetDesigningHR()
        {
            var designing_HR = await (from e2 in _context.Employees2
                                     where e2.emp_dept == "Designing" || e2.emp_dept == "HR"
                                     select e2).ToListAsync();

            return Ok(designing_HR);
        }

        // 4. Get the emp info who're getting the 50000 salaries or lang is C#
        [HttpGet("salaryorlang")]
        public async Task<IActionResult> GetSalaryOrLang()
        {
            var salaryOrLang = await (from e1 in _context.Employees1
                                      join e2 in _context.Employees2 on e1.emp_id equals e2.emp_id
                                      where e2.emp_salary == 50000 || e1.emp_lang == "C#"
                                      select new { e1.emp_id, e1.emp_name, e1.emp_lang, e2.emp_dept, e2.emp_salary }).ToListAsync();

            return Ok(salaryOrLang);
        }

        // 5. Get the emp count based on the dept
        [HttpGet("countbydept")]
        public async Task<IActionResult> GetEmpCountByDept()
        {
            var empCountByDept = await _context.Employees2
                .GroupBy(e => e.emp_dept)
                .Select(g => new { Department = g.Key, Count = g.Count() })
                .ToListAsync();

            return Ok(empCountByDept);
        }

        // 6. Display the data to whoever is not present in table2
        [HttpGet("notintable2")]
        public async Task<IActionResult> GetNotInTable2()
        {
            var notInTable2 = await (from e1 in _context.Employees1
                                     where !_context.Employees2.Any(e2 => e2.emp_id == e1.emp_id)
                                     select e1).ToListAsync();

            return Ok(notInTable2);
        }
    }

}
