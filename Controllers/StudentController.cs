using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInfoApp.Data;
using StudentInfoApp.Models;

namespace StudentInfoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentDbContext.Student.ToListAsync();

            return Ok(students);
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            await _studentDbContext.Student.AddAsync(student);
            await _studentDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(int id, Student updateStudent)
        {
            var student = await _studentDbContext.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            student.StudentName = updateStudent.StudentName;
            student.Course = updateStudent.Course;
            student.Specialization = updateStudent.Specialization;
            student.Percentage = updateStudent.Percentage;
            student.DepartmentID = updateStudent.DepartmentID;

            await _studentDbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent([FromQuery] int id)
        {
            var student = await _studentDbContext.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentDbContext.Student.Remove(student);
            await _studentDbContext.SaveChangesAsync();

            return Ok(student);
        }
    }
}
