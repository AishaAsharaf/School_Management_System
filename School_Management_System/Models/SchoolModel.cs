using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role {  get; set; }
        public string Password {  get; set; }
    }

    public class Student : User
    {
        public int StudentId { get; set; }
       
        
        public List<string> Courses { get; set; } = new List<string>();
        public List<string> Grades { get; set; } = new List<string>();

        public string CoursesString => string.Join(", ", Courses);
        public string GradesString => string.Join(", ", Grades);
    }

    public class Teacher : User
    {
        public int TeacherId { get; set; }
        public List<string> AssignedCourses { get; set; } = new List<string>();

        public string AssignedCoursesString => string.Join(", ", AssignedCourses);
    }

    public class Admin : User
    {
       
      public int AdminId { get; set; }
       
    }

}
