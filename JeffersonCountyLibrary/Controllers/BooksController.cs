using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JeffersonCountyLibrary.DataAccess;
using JeffersonCountyLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace JeffersonCountyLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(LibraryDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Books/Create
        [Authorize(Roles = "Librarian")]
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Librarian")]
        public IActionResult Create(Book book)
        {
            book.Branch = _context.Branches.Find(book.BranchId);

            _context.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Details", "Branches", new { id = book.BranchId });
        }

        [HttpGet]
        [Authorize]
        public IActionResult CheckOut(int? id)
        {
            var book = _context.Books.Find(id);
            var user = _context.Users.Find(_userManager.GetUserId(User));
            
            book.CheckedOutBy = user;
            book.DueDate = DateTime.UtcNow.AddDays(14);
            _context.SaveChanges();

            return RedirectToAction("Details", "Branches", new { id = book.BranchId });
        }
    }
}
