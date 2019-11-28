using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class PaintController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PaintController(IHostingEnvironment hostingEnvironment, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var reformImages = _context.ReformedImages.OrderByDescending(r => r.DateCreated)
                    .ThenByDescending(r => r.DateModified);

                if (HttpContext.User.IsInRole("Customer"))
                    reformImages.Where(r => r.UploadedImage.User.Id == _userManager.GetUserAsync(HttpContext.User).Result.Id);

                var uploadedImages = _context.UploadedImages.OrderByDescending(u => u.DateCreated)
                    .ThenByDescending(u => u.DateModified);

                if (HttpContext.User.IsInRole("Customer"))
                    uploadedImages.Where(u => u.User.Id == _userManager.GetUserAsync(HttpContext.User).Result.Id);

                var res = new UploadReformListViewModel(reformImages, uploadedImages);

                return View(res);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile source)
        {
            if (isFileImage(source))
            {
                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');

                filename = this.EnsureCorrectFilename(filename);

                string serverFilePath = this.GetPathAndFilename(filename);

                try
                {
                    await source.CopyToAsync(new FileStream(serverFilePath, FileMode.Create));

                    string username = "Guest" + HttpContext.Session.Id;
                    if (HttpContext.User.Identity.IsAuthenticated)
                        username = HttpContext.User.Identity.Name;

                    string imgUrl = $"\\images\\user\\{username}\\{filename}";

                    var routerVal = new { imgUrl };

                    await _context.UploadedImages.AddAsync(new UploadedImage
                    {
                        ImageUrl = imgUrl,
                        User = _userManager.GetUserAsync(HttpContext.User).Result
                    });
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Edit", routerVal);

                }
                catch
                { }
            }

            return View();
        }

        private bool isFileImage(IFormFile source)
        {
            var filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"').Split(".");

            var extension = filename[filename.Length - 1].ToLower();

            if (extension == "jpg" ||
                extension == "jpeg" ||
                extension == "png")
                return true;
            return false;
        }


        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal) + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            string username = "Guest" + HttpContext.Session.Id;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                username = HttpContext.User.Identity.Name;
            }

            //string path = this._hostingEnvironment.WebRootPath + $"\\images\\user\\{username}\\";
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images/user/" + username, filename);

            return path;

        }
        public IActionResult Edit(string imgUrl)
        {
            ViewData.Model = imgUrl;
            return View();
        }
    }
}