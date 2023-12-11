using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; } 

        public DbSet<CourseRegistration> courseRegistrations {get ; set ;}
        public DbSet<Instructor> Instructors {get; set;}
        
        

    }
}