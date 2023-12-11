using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class InstructorController : Controller
    {
        private readonly CourseContext _context;
        public InstructorController(CourseContext courseContext)
        {
            _context = courseContext;
        }
        public  IActionResult CreateInstructor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructor(Instructor model)
        {
            model.StartDate = DateTime.Now;
            if(ModelState.IsValid)
            {
                _context.Instructors.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("InstructorList","Instructor");
            }
            return View();
        }

        public async Task<IActionResult> InstructorList()
        {
            var instructors = await _context.Instructors.ToListAsync();
            return View(instructors);
        }

        public async Task<IActionResult> DeleteInstructor(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = await _context.Instructors.FirstOrDefaultAsync(i => i.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost] 
        public async Task<IActionResult> DeleteInstructor(int? id,Instructor model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try{
                    _context.Instructors.Remove(model);
                    await _context.SaveChangesAsync();
                }catch(Exception){
                    if(!_context.Instructors.Any(i => i.Id==id))
                    {
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction("InstructorList","Instructor");
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id ==null)
            {
                return NotFound();
            }
            var model = await _context
                                    .Instructors
                                    .FirstOrDefaultAsync(i => i.Id == id);
        
            if(model == null)
            {
                return NotFound();
            }
            
            return View(model);
        }

        public async Task<IActionResult> EditInstructor(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = await _context.Instructors.FirstOrDefaultAsync(s => s.Id == id);
            if(model ==null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditInstructor(int? id,Instructor model)
        {
            if( id != model.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try{
                    _context.Instructors.Update(model);
                     await _context.SaveChangesAsync();
                }catch(Exception)
                {
                    if(!_context.Instructors.Any(s=> s.Id == id))
                    {
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction("InstructorList","Instructor");
            }
            return View(model);
        }

    }
}