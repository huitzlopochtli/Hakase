using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public IActionResult Index()
        {
            ApplicationDbInitializer.SeedUsers(_userManager, _roleManager, _context);
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                    return LocalRedirect("~/Admin");
                else
                    return View();
            }
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return LocalRedirect("~/Identity/Account/Login");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return LocalRedirect("~/Identity/Account/Login");
            
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return LocalRedirect("~/Identity/Account/Login");
            return View();
        }

        public IActionResult Privacy()
        {
            return LocalRedirect("~/Identity/Account/Login");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
