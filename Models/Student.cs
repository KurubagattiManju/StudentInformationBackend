using System.ComponentModel.DataAnnotations;

namespace StudentInfoApp.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set;}
        public string Specialization { get; set; }
        public float Percentage { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
