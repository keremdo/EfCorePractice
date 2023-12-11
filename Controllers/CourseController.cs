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
    public class CourseController : Controller
    {
        private readonly CourseContext _course;
        public CourseController(CourseContext courseContext)
        {
            _course = courseContext;
        }

        public async Task<IActionResult> CreateCourse()
        {
            ViewBag.Instructors = new SelectList(await _course.Instructors.ToListAsync(),"Id","NameSurname");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(Course model)
        {
            if(ModelState.IsValid)
            {
                _course.Courses.Add(model);
                await _course.SaveChangesAsync();
                return RedirectToAction("CourseList","Course");
            }
            return View();
        }

        public async Task<IActionResult> CourseList()
        {
            var courseList = await _course.Courses.ToListAsync();
            return View(courseList);
        }

       public async Task<IActionResult> EditCourse(int? id)
       {
        if(id == null && id == 0)
        {
            return NotFound();
        }
        var model = await _course
                            .Courses
                            .Include(x => x.courseRegistrations)
                            .ThenInclude(x => x.student)
                            .FirstOrDefaultAsync(c => c.Id==id);
        if(model ==null)
        {
            return NotFound();
        }
        ViewBag.Instructors = new SelectList(await _course.Instructors.ToListAsync(),"Id","NameSurname");
        return View(model);
       }

       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> EditCourse(int? id, Course model)
       {
            if(id != model.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try{
                    _course.Courses.Update(model);
                    await _course.SaveChangesAsync();
                }catch(Exception){
                    if(!_course.Courses.Any(c => c.Id==model.Id))
                    {
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction("CourseList","Course");
            }
            
            return View(model);
       }

       public async Task<IActionResult> DeleteCourse(int? id)
       {
            if(id == null)
            {
                return NotFound();
            }
            var model = await _course.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
       }

       [HttpPost]
       public async Task<IActionResult> DeleteCourse(int? id,Course model)
       {
            if(id != model.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try{
                    _course.Remove(model);
                    await _course.SaveChangesAsync();
                }catch(Exception)
                {
                    if(!_course.Courses.Any(c => c.Id == model.Id)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction("CourseList","Course");
            }
            return View(model);
       }
    }
}