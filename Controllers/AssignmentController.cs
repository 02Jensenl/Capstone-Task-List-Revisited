using CapstoneToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CapstoneToDo.Controllers
{
    [Authorize]
    public class AssignmentController : Controller
    {
        private readonly CapstoneToDoDBContext _context;

        public AssignmentController(CapstoneToDoDBContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value; // Grabbing the Currently Loggin in Users Id (Primary Key)

            var assignments = _context.ToDoItem.Where(x => x.UserId == id).ToList(); // Matching Currently Logged in User to Database Entries.

            return View(assignments);
        }

        // Create View Form
        [HttpGet]
        public IActionResult AddAssignment()
        {
            return View(new ToDoItem());
        }

        // Create Add
        [HttpPost]
        public IActionResult AddAssignment(ToDoItem assignment)
        {
            if (ModelState.IsValid)
            {
                assignment.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                // Add to the database
                _context.ToDoItem.Add(assignment);

                // Save changes to database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(AddAssignment), assignment);
        }

        // Edit
        [HttpGet]
        public IActionResult Update(int Id)
        {
            ToDoItem t = _context.ToDoItem.Find(Id);
            return View(t);
            
        }


        [HttpPost]
        public IActionResult Update(bool Complete)
        {
            
            _context.SaveChanges(Complete);
            
           
                return RedirectToAction("Index");
           
           
        }
        // Delete

       
        public IActionResult Delete(int Id)
        {
            ToDoItem t = _context.ToDoItem.Find(Id);
            return View(t);
        }


        [HttpPost]
        public IActionResult Delete(ToDoItem assignment)
        {

            _context.ToDoItem.Remove(assignment);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }




    }
}