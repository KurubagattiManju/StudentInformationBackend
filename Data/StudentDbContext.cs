using Microsoft.EntityFrameworkCore;
using StudentInfoApp.Models;

namespace StudentInfoApp.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<User> User { get; set; }        
    }
}
