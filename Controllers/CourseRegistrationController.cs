using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class CourseRegistrationController: Controller
    {
        private readonly CourseContext _context;
        public CourseRegistrationController(CourseContext courseContext)
        {
            _context = courseContext;
        }

        public IActionResult RegistrationList()
        {
            var listRegistration = _context.courseRegistrations
                                    .Include(x => x.student)
                                    .Include(z => z.course)
                                    .ToList();
            return View(listRegistration);
        }

        public IActionResult AddRegistration()
        {
            ViewBag.Students = new SelectList(_context.Students.ToList(),"Id","NameSurname");
            ViewBag.Courses = new SelectList(_context.Courses.ToList(),"Id","CourseName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRegistration(CourseRegistration model)
        {
                model.dateTime = DateTime.Now;
                _context.courseRegistrations.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("RegistrationList","CourseRegistration");  
        }
    }
}