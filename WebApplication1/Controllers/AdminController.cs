using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

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
            ViewBag.CustomerCount = _context.Customers.Count();
            ViewBag.UserCount = _userManager.Users.Count();
            return View();
        }

        public async Task<IActionResult> UserPage()
        {


            var users = _userManager.Users;
            List < DUser > dUsers= new List<DUser>();
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

        public IActionResult CustomerPage()
        {
            return View(_context.Customers);
        }
    }
    public class DUser
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }
}

