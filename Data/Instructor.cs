using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Instructor
    {
        [Key]
        public int Id {get; set;}
        public string? InstructorName { get; set; }
        public string? InstructorSurName { get; set; }

        public string? NameSurname { get{
            return InstructorName + " " + InstructorSurName;
        }}
        public string? InstructorEmail { get; set; }
        public string? Phone { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<Course> courses {get;set;} = new List<Course>();
    }
}