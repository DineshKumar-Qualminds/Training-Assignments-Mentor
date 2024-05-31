using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAPIWithLINQ.Data;
using WebAPIWithLINQ.Model;

namespace WebAPIWithLINQ.Controllers
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

        [HttpGet("get/all-employeeData")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeDetails()
        {


        /*    var employeesWithDepartments = (from e in _context.Employees
                                            join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                                            select new
                                            {
                                                EmployeeId = e.EmployeeId,
                                                Name = e.Name,
                                                Age = e.Age,
                                                DepartmentId = e.DepartmentId,
                                                DepartmentName = d.Name
                                            });
            return Ok(employeesWithDepartments);
*/


            //Eagar Loading
            var employees = _context.Employees.Include(e => e.Department).
                                                    Select(e => new
                                                    {
                                                        e.EmployeeId,
                                                        e.Name,
                                                        e.Age,
                                                        DepartmentName = e.Department.Name
                                                    });
            return Ok(employees);


/*            var employeesWithDepartments = await (from e in _context.Employees
                                                  join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                                                  select new
                                                  {
                                                      EmployeeId = e.EmployeeId,
                                                      Name = e.Name,
                                                      Age = e.Age,
                                                      DepartmentId = e.DepartmentId,
                                                      DepartmentName = d.Name
                                                  }).ToListAsync();

            var result = new List<object>();

            foreach (var emp in employeesWithDepartments)
            {
                var employee = new
                {
                    EmployeeId = emp.EmployeeId,
                    Name = emp.Name,
                    Age = emp.Age,
                    DepartmentId = emp.DepartmentId,
                    DepartmentName = emp.DepartmentName
                };

                result.Add(employee);
            }

            return Ok(result);
*/


        }
        [HttpGet("where-age>27")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeDetailsWithWhere()
        {
            var employees = await _context.Employees.Include(e => e.Department).
                                                    Select(e => new
                                                    {
                                                        e.EmployeeId,
                                                        e.Name,
                                                        e.Age,
                                                        DepartmentName = e.Department.Name
                                                    }).Where(e => e.Age > 27).ToListAsync();
            return Ok(employees);

        /*    var employeesWithDepartments = (from e in _context.Employees
                                            join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                                            select new
                                            {
                                                EmployeeId = e.EmployeeId,
                                                Name = e.Name,
                                                Age = e.Age,
                                                DepartmentId = e.DepartmentId,
                                                DepartmentName = d.Name
                                            }).Where(e => e.Age > 27);
            return Ok(employeesWithDepartments);
*/
        }


        [HttpGet("aggregate-functions")]
        public IActionResult GetAggegationFunctions()
        {
            var employeeCount = _context.Employees.Count();
            var averageAge = _context.Employees.Average(e => e.Age);
            var sumofAgeEmployee = _context.Employees.Sum(e => e.Age);
            var HighAgeEmployee = _context.Employees.Max(e => e.Age);
            var smallAgeEmployee = _context.Employees.Min(e => e.Age);
            return Ok(new { employeeCount, averageAge, sumofAgeEmployee, HighAgeEmployee, smallAgeEmployee });
        }







        [HttpGet("joinTables")]
        public async Task<ActionResult> GetEmployeeDetailsWithJoin()
        {
            var result = await _context.Employees
                                                .Join(_context.Departments,
                                                e => e.DepartmentId,
                                                d => d.DepartmentId,
                                                (e, d) => new
                                                {
                                                    EmployeeName = e.Name,
                                                    DepartmentName = d.Name,
                                                }).ToListAsync();
            return Ok(result);


          /*  var employeesWithDepartments = (from e in _context.Employees
                                            join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                                            select new
                                            {
                                                EmployeeId = e.EmployeeId,
                                                Name = e.Name,

                                                DepartmentId = e.DepartmentId,
                                                DepartmentName = d.Name
                                            });
            return Ok(employeesWithDepartments);
*/
        }

        [HttpGet("SortByName")]
        public async Task<ActionResult> GetDetaWithSorting()
        {
            var employees = await _context.Employees.Include(e => e.Department).
                                                    Select(e => new
                                                    {
                                                        e.EmployeeId,
                                                        e.Name,
                                                        e.Age,
                                                        DepartmentName = e.Department.Name
                                                    }).OrderBy(e => e.Name).ToListAsync();

            return Ok(employees);

         /*   var employeesWithDepartments = (from e in _context.Employees
                                            join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                                            select new
                                            {
                                                EmployeeId = e.EmployeeId,
                                                Name = e.Name,
                                                Age = e.Age,
                                                DepartmentId = e.DepartmentId,
                                                DepartmentName = d.Name
                                            }).OrderBy(e => e.Name);
            return Ok(employeesWithDepartments);*/


        }

        [HttpGet("GroupByDepartment")]
        public async Task<ActionResult> GetDataWithGrouping()
        {
            var result = await _context.Employees
                              .GroupBy(e => new { e.DepartmentId, e.Department.Name })
                              .Select(g => new
                              {
                                  DepartmentId = g.Key.DepartmentId,
                                  DepartmentName = g.Key.Name,
                                  Employees = g.Select(e => new { e.EmployeeId, e.Name }).ToList()
                              }).ToListAsync();
            return Ok(result);

         /*   var employeesWithDepartments = (from e in _context.Employees
                                            join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                                            select new
                                            {
                                                EmployeeId = e.EmployeeId,
                                                Name = e.Name,
                                                Age = e.Age,
                                                DepartmentId = e.DepartmentId,
                                                DepartmentName = d.Name
                                            }).GroupBy(e => new { e.DepartmentId, e.DepartmentName })
                                             .Select(g => new
                                             {
                                                 DepartmentId = g.Key.DepartmentId,
                                                 DepartmentName = g.Key.DepartmentName,
                                                 Employees = g.Select(e => new { e.EmployeeId, e.Name })
                                             });
            return Ok(employeesWithDepartments);
*/


        }



        // GroupJoin
        [HttpGet("groupJoin")]
        public async Task<ActionResult> GetEmployeeDetailsWithGroupJoin()
        {
            var departments = await _context.Departments
                                            .GroupJoin(
                                                _context.Employees,
                                                d => d.DepartmentId,
                                                e => e.DepartmentId,
                                                (d, employees) => new
                                                {
                                                    DepartmentName = d.Name,
                                                    Employees = employees.Select(e => new { e.EmployeeId, e.Name })
                                                }).ToListAsync();
            return Ok(departments);
        }

        // SelectMany
        [HttpGet("selectMany")]
        public async Task<ActionResult> GetEmployeeDetailsWithSelectMany()
        {
            var employeesWithDepartments = await _context.Departments
                                                         .SelectMany(d => _context.Employees
                                                                                   .Where(e => e.DepartmentId == d.DepartmentId)
                                                                                   .Select(e => new
                                                                                   {
                                                                                       e.EmployeeId,
                                                                                       e.Name,
                                                                                       DepartmentName = d.Name
                                                                                   })).ToListAsync();
            return Ok(employeesWithDepartments);
        }

        // OrderByDescending
        [HttpGet("orderByDescending")]
        public async Task<ActionResult> GetDetailsWithOrderByDescending()
        {
            var employees = await _context.Employees
                                          .Include(e => e.Department)
                                          .Select(e => new
                                          {
                                              e.EmployeeId,
                                              e.Name,
                                              e.Age,
                                              DepartmentName = e.Department.Name
                                          })
                                          .OrderByDescending(e => e.Name)
                                          .ToListAsync();
            return Ok(employees);
        }

        // ThenBy and ThenByDescending
        [HttpGet("thenBy")]
        public async Task<ActionResult> GetDetailsWithThenBy()
        {
            var employees = await _context.Employees
                                          .Include(e => e.Department)
                                          .Select(e => new
                                          {
                                              e.EmployeeId,
                                              e.Name,
                                              e.Age,
                                              DepartmentName = e.Department.Name
                                          })
                                          .OrderBy(e => e.DepartmentName)
                                          .ThenBy(e => e.Name)
                                          .ToListAsync();
            return Ok(employees);
        }

        // Reverse
        [HttpGet("reverse")]
        public async Task<ActionResult> GetDetailsWithReverse()
        {
            var employees = await _context.Employees
                                          .Include(e => e.Department)
                                          .Select(e => new
                                          {
                                              e.EmployeeId,
                                              e.Name,
                                              e.Age,
                                              DepartmentName = e.Department.Name
                                          })
                                          .ToListAsync();
            employees.Reverse();
            return Ok(employees);
        }



        // Concat
        [HttpGet("concat")]
        public async Task<ActionResult> GetDetailsWithConcat()
        {
            var employees = await _context.Employees
                                          .Include(e => e.Department)
                                          .Select(e => new
                                          {
                                              Id = e.EmployeeId,
                                              Name = e.Name,
                                              Age = e.Age,
                                              DepartmentName = e.Department.Name
                                          })
                                          .ToListAsync();

            var departments = await _context.Departments
                                            .Select(d => new
                                            {
                                                Id = d.DepartmentId,
                                                Name = d.Name
                                            })
                                            .ToListAsync();

            var concatenatedList = employees.Select(e => new { e.Id, e.Name })
                                            .Concat(departments.Select(d => new { d.Id, d.Name }));

            return Ok(concatenatedList);
        }


        // Aggregate
        [HttpGet("aggregate-method")]
        public IActionResult GetDetailsWithAggregate()
        {
            // Select all employee names from the database
            var employeeNames = _context.Employees
                                        .Select(e => e.Name)
                                        .ToList();

            // Handle empty list case using Aggregate safely
            var allEmployeeNames = employeeNames.Count > 0
                ? employeeNames.Aggregate((current, next) => current + ", " + next)
                : "No employees found";

            return Ok(new { allEmployeeNames });
        }

        // All
        [HttpGet("all")]
        public IActionResult CheckAllEmployeesAbove18()
        {
            var allEmployeesAbove18 = _context.Employees.All(e => e.Age > 18);
            return Ok(new { allEmployeesAbove18 });
        }


        // Any
        [HttpGet("any")]
        public IActionResult CheckAnyEmployeeBelow18()
        {
            var anyEmployeeBelow18 = _context.Employees.Any(e => e.Age < 18);
            return Ok(new { anyEmployeeBelow18 });
        }

        // Contains
        [HttpGet("contains")]
        public IActionResult CheckEmployeeContains()
        {
            var employeeNames = _context.Employees.Select(e => e.Name).ToList();
            var containsEmployee = employeeNames.Contains("Ram");
            return Ok(new { containsEmployee });
        }

        // Skip
        [HttpGet("skip")]
        public async Task<ActionResult> GetDetailsWithSkip()
        {
            var employees = await _context.Employees
                                          .Include(e => e.Department)
                                          .Skip(5)
                                          .Select(e => new
                                          {
                                              e.EmployeeId,
                                              e.Name,
                                              e.Age,
                                              DepartmentName = e.Department.Name
                                          })
                                          .ToListAsync();
            return Ok(employees);
        }
        //skipWhile
        [HttpGet("skipWhile")]
        public async Task<ActionResult> GetDetailsWithSkipWhile()
        {
            // Fetch data from the database and include the related Department entity
            var employees = await _context.Employees
                                          .Include(e => e.Department)
                                          .OrderBy(e => e.Age) // Sort by age first
                                          .ToListAsync(); // Fetch data to memory

            // Apply SkipWhile in memory
            var filteredEmployees = employees.AsEnumerable()
                                             .SkipWhile(e => e.Age < 30) // Skip while age is less than 30
                                             .Select(e => new
                                             {
                                                 e.EmployeeId,
                                                 e.Name,
                                                 e.Age,
                                                 DepartmentName = e.Department.Name
                                             })
                                             .ToList();

            // Return the filtered employees
            return Ok(filteredEmployees);
        }



        // Partition Operations: Take
        [HttpGet("take")]
        public async Task<ActionResult> GetDetailsWithTake()
        {
            var employees = await _context.Employees
                                          .Include(e => e.Department)
                                          .Take(5)
                                          .Select(e => new
                                          {
                                              e.EmployeeId,
                                              e.Name,
                                              e.Age,
                                              DepartmentName = e.Department.Name
                                          })
                                          .ToListAsync();
            return Ok(employees);
        }

        // Partition Operations: TakeWhile
        [HttpGet("takeWhile")]
        public async Task<ActionResult> GetDetailsWithTakeWhile()
        {
            // Fetch data from the database and include the related Department entity
            var employees = await _context.Employees
                                          .Include(e => e.Department)
                                          .OrderBy(e => e.Age) 
                                          .ToListAsync(); // Fetch data to memory

            // Apply SkipWhile in memory
            var filteredEmployees = employees.AsEnumerable()
                                             .TakeWhile(e => e.Age < 30) 
                                             .Select(e => new
                                             {
                                                 e.EmployeeId,
                                                 e.Name,
                                                 e.Age,
                                                 DepartmentName = e.Department.Name
                                             })
                                             .ToList();

         
            return Ok(filteredEmployees);
        }



        // DefaultIfEmpty
        [HttpGet("defaultIfEmpty")]
        public IActionResult GetDetailsWithDefaultIfEmpty()
        {
            var employees = _context.Employees
                                    .Where(e => e.Age > 100)
                                    .ToList() // Fetch data to memory
                                    .DefaultIfEmpty(new Employee { EmployeeId = 0, Name = "No Employee", Age = 0 }) // Apply DefaultIfEmpty in memory
                                    .Select(e => new
                                    {
                                        e.EmployeeId,
                                        e.Name,
                                        e.Age
                                    });
            return Ok(employees);
        }


        // Generation Operations: Empty
        [HttpGet("empty")]
        public IActionResult GetEmptySequence()
        {
            var emptySequence = Enumerable.Empty<Employee>();
            return Ok(emptySequence);
        }

        // Generation Operations: Range
        [HttpGet("range")]
        public IActionResult GetRange()
        {
            var range = Enumerable.Range(1, 10);
            return Ok(range);
        }

        // Generation Operations: Repeat
        [HttpGet("repeat")]
        public IActionResult GetRepeat()
        {
            var repeatedSequence = Enumerable.Repeat("Hello", 5);
            return Ok(repeatedSequence);
        }

        // Set Operations: Distinct
        [HttpGet("distinct")]
        public async Task<ActionResult> GetDetailsWithDistinct()
        {
            var departments = await _context.Departments
                                            .Select(d => d.Name)
                                            .Distinct()
                                            .ToListAsync();
            return Ok(departments);
        }

        // Set Operations: Except
        [HttpGet("except")]
        public async Task<ActionResult> GetDetailsWithExcept()
        {
            var allDepartments = await _context.Departments.Select(d => d.Name).ToListAsync();
            var departmentsInUse = await _context.Employees.Select(e => e.Department.Name).Distinct().ToListAsync();
            var unusedDepartments = allDepartments.Except(departmentsInUse);
            return Ok(unusedDepartments);
        }

        // Set Operations: Intersect
        [HttpGet("intersect")]
        public async Task<ActionResult> GetDetailsWithIntersect()
        {
            var allDepartments = await _context.Departments.Select(d => d.Name).ToListAsync();
            var departmentsInUse = await _context.Employees.Select(e => e.Department.Name).Distinct().ToListAsync();
            var commonDepartments = allDepartments.Intersect(departmentsInUse);
            return Ok(commonDepartments);
        }

        // Set Operations: Union
        [HttpGet("union")]
        public async Task<ActionResult> GetDetailsWithUnion()
        {
            var departmentsInUse = await _context.Employees.Select(e => e.Department.Name).Distinct().ToListAsync();
            var allDepartments = await _context.Departments.Select(d => d.Name).ToListAsync();
            var unionDepartments = departmentsInUse.Union(allDepartments);
            return Ok(unionDepartments);
        }

        // Equality: SequenceEqual
        [HttpGet("sequenceEqual")]
        public IActionResult CheckSequenceEqual()
        {
            var sequence1 = _context.Employees.Select(e => e.Name).ToList();
            var sequence2 = _context.Employees.Select(e => e.Name).ToList();
            var areSequencesEqual = sequence1.SequenceEqual(sequence2);
            return Ok(new { areSequencesEqual });
        }

        // Element Operators: ElementAt
        [HttpGet("elementAt")]
        public IActionResult GetElementAt()
        {
            var employee = _context.Employees.OrderBy(e => e.EmployeeId).ElementAt(3);
            return Ok(employee);
        }

        // Element Operators: ElementAtOrDefault
        [HttpGet("elementAtOrDefault")]
        public IActionResult GetElementAtOrDefault()
        {
            var employee = _context.Employees.OrderBy(e => e.EmployeeId).ElementAtOrDefault(3);
            return Ok(employee);
        }

        // Element Operators: First
        [HttpGet("first")]
        public IActionResult GetFirst()
        {
            var employee = _context.Employees.OrderBy(e => e.EmployeeId).First();
            return Ok(employee);
        }

        // Element Operators: FirstOrDefault
        [HttpGet("firstOrDefault")]
        public IActionResult GetFirstOrDefault()
        {
            var employee = _context.Employees.OrderBy(e => e.EmployeeId).FirstOrDefault();
            return Ok(employee);
        }

        // Element Operators: Last
        [HttpGet("last")]
        public IActionResult GetLast()
        {
            var employee = _context.Employees.OrderBy(e => e.EmployeeId).Last();
            return Ok(employee);
        }

        // Element Operators: LastOrDefault
        [HttpGet("lastOrDefault")]
        public IActionResult GetLastOrDefault()
        {
            var employee = _context.Employees.OrderBy(e => e.EmployeeId).LastOrDefault();
            return Ok(employee);
        }

        // Element Operators: Single
        [HttpGet("single")]
        public IActionResult GetSingle()
        {
            var employee = _context.Employees.Single(e => e.EmployeeId == 1);
            return Ok(employee);
        }

        // Element Operators: SingleOrDefault
        [HttpGet("singleOrDefault")]
        public IActionResult GetSingleOrDefault()
        {
            var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == 1);
            return Ok(employee);
        }

    }

}
