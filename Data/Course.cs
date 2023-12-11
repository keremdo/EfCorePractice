using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public string? CourseTitle { get; set; }
        public int? InstructorId { get; set; }
        public Instructor instructor {get; set;} = null!;
        public ICollection<CourseRegistration> courseRegistrations {get;set;} = new List<CourseRegistration>();
    }
}