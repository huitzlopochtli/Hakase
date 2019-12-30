using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.MaterialCount = !_context.Materials.Any() ? 0 : _context.Materials.Count();
            ViewBag.CustomerCount = _context.Customers.Count();
            ViewBag.UserCount = _userManager.Users.Count();
            return View();
        }

        public async Task<IActionResult> UserPage()
        {
            var users = _userManager.Users;
            List<DUser> dUsers = new List<DUser>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                string role = "";
                if (roles[0] == "Admin")
                    role = "管理者";
                else if (roles[0] == "Customer")
                    role = "お客様";
                dUsers.Add(new DUser()
                {
                    Username = user.Email,
                    Role = role
                });
            }

            return View(dUsers);
        }

        public async Task<IActionResult> CustomerPage()
        {
            var users = _userManager.Users;
            var customers = _context.Customers.OrderByDescending(c => c.DateCreated);
            foreach (var customer in customers)
            {
                foreach (var user in users)
                {
                    if (user.Id == customer.UserId)
                        customer.User.Email = user.Email;
                }
            }

            return View(customers);
        }

        public async Task<IActionResult> CustomerEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            ViewBag.UserEmail = await _userManager.Users.Where(u => u.Id == customer.UserId).FirstOrDefaultAsync();
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerEdit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                TempData["Success"] = $"更新しました。";
                return RedirectToAction(nameof(CustomerPage));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", customer.UserId);
            return View(customer);
        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> CustomerDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("CustomerDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CustomerPage));
        }
    }
    public class DUser
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }
}

