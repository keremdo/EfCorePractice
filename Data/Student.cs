using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? StudentSurName { get; set; }
        public string? NameSurname { 
            get
            {
                return this.StudentName+ " " + this.StudentSurName;
            }
        }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<CourseRegistration> courseRegistrations {get;set;}= new List<CourseRegistration>();
    }
}