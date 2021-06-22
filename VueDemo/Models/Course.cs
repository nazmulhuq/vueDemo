using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace VueDemo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public long CourseFee { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }  
    }
}
