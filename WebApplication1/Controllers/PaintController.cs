using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class PaintController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}