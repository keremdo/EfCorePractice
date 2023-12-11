using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class CourseRegistration
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student student {get;set;} = null!;
        public int CourseId { get; set; }
        public Course course {get; set;} = null!;
        public DateTime dateTime {get; set;}
    }
}