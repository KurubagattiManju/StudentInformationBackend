using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInfoApp.Data;
using StudentInfoApp.Models;

namespace StudentInfoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly StudentDbContext _studentDbContext;

        public DepartmentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _studentDbContext.Department.ToListAsync();

            return Ok(departments);
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
            await _studentDbContext.Department.AddAsync(department);
            await _studentDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromQuery] int id, Department updateDepartment)
        {
            var department = await _studentDbContext.Department.FindAsync(id);

            if(department == null)
            {
                return NotFound();
            }

            department.DepartmentName = updateDepartment.DepartmentName;

            await _studentDbContext.SaveChangesAsync();

            return Ok(department);
        }

        [HttpDelete]
        [Route("DeleteDepartment/")]
        public async Task<IActionResult> DeleteDepartment([FromQuery] int id)
        {
            var department = await _studentDbContext.Department.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            _studentDbContext.Department.Remove(department);
            await _studentDbContext.SaveChangesAsync();

            return Ok(department);
        }
    }
}
