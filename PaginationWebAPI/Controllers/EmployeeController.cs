using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginationWebAPI.Data;
using PaginationWebAPI.Model;


namespace PaginationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployees(int page = 1, int pageSize = 10)
        {
            var employees = _context.EmployeesData
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var employeeDataList = _mapper.Map<List<EmployeeDetailsDto>>(employees);

            return Ok(employeeDataList);
        }
    }
}
