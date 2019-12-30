using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return RedirectToAction(nameof(Upload));
        }

        public IActionResult Upload()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                if (HttpContext.User.IsInRole("Admin"))
                {
                    var reformImages = _context.ReformedImages.OrderByDescending(r => r.DateCreated)
                        .ThenByDescending(r => r.DateModified);
                    var uploadedImages = _context.UploadedImages.OrderByDescending(u => u.DateCreated)
                        .ThenByDescending(u => u.DateModified);
                    var res = new UploadReformListViewModel(reformImages, uploadedImages);
                    return View(res);
                }
                else
                {
                    var reformImages = _context.ReformedImages.Where(r => r.UploadedImage.UserCreated == HttpContext.User.Identity.Name).OrderByDescending(r => r.DateCreated)
                        .ThenByDescending(r => r.DateModified);
                    var uploadedImages = _context.UploadedImages.Where(u => u.UserCreated == HttpContext.User.Identity.Name).OrderByDescending(u => u.DateCreated)
                        .ThenByDescending(u => u.DateModified);
                    var res = new UploadReformListViewModel(reformImages, uploadedImages);
                    return View(res);
                }

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
                catch (Exception e)
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

            string pathD = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "user", username);

            if (!Directory.Exists(pathD))
                Directory.CreateDirectory(pathD);

            //string path = this._hostingEnvironment.WebRootPath + $"\\images\\user\\{username}\\";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "user", username, filename);

            return path;

        }
        public IActionResult Edit(string imgUrl)
        {
            ViewData.Model = imgUrl;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> DeleteUploadedImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _context.UploadedImages
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (!User.IsInRole("Admin") && res.User.UserName != HttpContext.User.Identity.Name)
                return NotFound();

            if (res == null)
            {
                return NotFound();
            }

            return View(res);
        }

        [HttpPost, ActionName("DeleteUploadedImage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUploadedImagePostback(int? id)
        {
            var uploadedImg = await _context.UploadedImages.FindAsync(id);
            _context.UploadedImages.Remove(uploadedImg);

            await _context.SaveChangesAsync();
            return RedirectToAction("Upload");
        }


        [HttpPost]
        public async Task<IActionResult> UploadReform([FromBody] IFormFile file, [FromQuery] int? id)
        {
            if (file == null && id == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}