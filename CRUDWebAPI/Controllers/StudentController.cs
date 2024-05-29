using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoutingInWebAPI.Data;
using RoutingInWebAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingInWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public StudentsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Students/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/get/{id}
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // GET: api/Students/byname/{name}
        [HttpGet("byname/{name}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByName(string name)
        {
            var students = await _context.Students
                .Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name))
                .ToListAsync();

            if (students == null)
            {
                return NotFound();
            }

            return students;
        }

        // GET: api/Students/bycourse/{course}
        [HttpGet("bycourse/{course}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByCourse(string course)
        {
            var students = await _context.Students
                .Where(s => s.Courses.Contains(course))
                .ToListAsync();

            if (students == null)
            {
                return NotFound();
            }

            return students;
        }

        // POST: api/Students/add
        [HttpPost("add")]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT: api/Students/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // DELETE: api/Students/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
