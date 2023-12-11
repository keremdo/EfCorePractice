using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class StudentController: Controller
    {
        private readonly CourseContext _context;
        public StudentController(CourseContext courseContext)
        {
            _context = courseContext;
        }
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student model)
        {
            if(model != null)
            {
                _context.Students.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("StudentList","Student");
            }
            return View();
            
        }

        public async Task<IActionResult> StudentList()
        {
            var studentList = await _context.Students.ToListAsync();
            return View(studentList);
        }

        public async Task<IActionResult> EditStudent(int? id)
        {
            if(id == null && id == 0)
            {
                return NotFound();
            }
            var model = await _context.Students.FirstOrDefaultAsync(s => s.Id ==id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudent(int id,Student student)
        {
            if(id != student.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try{
                _context.Update(student);
                await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                if(!_context.Students.Any(s => s.Id == student.Id))
                {
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return RedirectToAction("StudentList","Student");
            }           
            
            return View(student);
        }

        public async Task<IActionResult> DeleteStudent(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var entity = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if(entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id,Student student)
        {
            if(id != student.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try{
                    _context.Remove(student);
                    await _context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if(!_context.Students.Any(s => s.Id == student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("StudentList","Student");
            }
            return View(student);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var entity = await _context
                                .Students
                                .Include(x=> x.courseRegistrations)
                                .ThenInclude(x=>x.course)
                                .FirstOrDefaultAsync(s => s.Id ==id);
            if(entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        
    }
}