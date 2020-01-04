using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MaterialsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Materials
        public async Task<IActionResult> Index(int? pageNumber = 1, int pageSize = 5)
        {
            var applicationDbContext = _context.Materials.Include(m => m.User).OrderByDescending(m => m.DateCreated).ThenByDescending(m => m.DateModified);
            var aa = await PaginatedList<Material>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1,
                pageSize);
            return View(applicationDbContext);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> MaterialThumbnails(int pageNumber = 1, int pageSize = 5)
        {
            var res = await _context.Materials.OrderBy(m => m.Precedence).ThenByDescending(m => m.DateCreated)
                .ThenBy(m => m.DateModified).Select(m =>
                    new
                    {
                        id = m.Id,
                        name = m.Name,
                        thumbnail = m.ImageThumbnailUrl3,
                        image = m.ImageThumbnailUrl1,
                        gridImage = m.ImageThumbnailUrl1
                    }
                    )
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalPage = (int) Math.Ceiling(decimal.Divide(_context.Materials.Count(), pageSize));

            var data = new
            {
                prevPage = (pageNumber - 1 == 0) ? -1 : pageNumber - 1,
                nextPage = pageNumber + 1 > totalPage ? -1 : pageNumber + 1,
                pageNumber = pageNumber,
                pageSize = pageSize,
                totalPage = totalPage,
                data = res
            };

            return Json(data);
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Type")]Material model, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                if (isFileImage(file))
                {
                    string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');

                    filename = this.EnsureCorrectFilename(filename);

                    string materialName = filename.Split(".")[0];

                    string serverFilePath = this.GetPathAndFilename(filename);

                    try
                    {
                        await file.CopyToAsync(new FileStream(serverFilePath, FileMode.Create));
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {

                        try
                        {

                            using (var image = new MagickImage(serverFilePath))
                            {
                                image.Resize(40, 40);
                                image.Strip();
                                image.Quality = 100;
                                image.Write(this.GetPathAndFilename("thumbnailUrl4" + filename));
                            }

                            using (var image = new MagickImage(serverFilePath))
                            {
                                image.Resize(995, 665);
                                image.Strip();
                                image.Quality = 100;
                                image.Write(this.GetPathAndFilename("thumbnailUrl1" + filename));
                            }

                            using (var image = new MagickImage(serverFilePath))
                            {
                                image.Resize(400, 400);
                                image.Strip();
                                image.Quality = 100;
                                image.Write(this.GetPathAndFilename("thumbnailUrl2" + filename));
                            }

                            using (var image = new MagickImage(serverFilePath))
                            {
                                image.Resize(200, 200);
                                image.Strip();
                                image.Quality = 100;
                                image.Write(this.GetPathAndFilename("thumbnailUrl3" + filename));
                            }

                            model.ImageUrl = "/images/materials/" + filename;
                            model.ImageThumbnailUrl1 = "/images/materials/thumbnailUrl1" + filename;
                            model.ImageThumbnailUrl2 = "/images/materials/thumbnailUrl2" + filename;
                            model.ImageThumbnailUrl3 = "/images/materials/thumbnailUrl3" + filename;
                            model.ImageThumbnailUrl4 = "/images/materials/thumbnailUrl4" + filename;
                            model.User = await _userManager.GetUserAsync(HttpContext.User);


                            await _context.AddAsync(model);
                            await _context.SaveChangesAsync();


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error", e);
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }

            }
            return View();
        }



        //// GET: Materials/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var material = await _context.Materials.FindAsync(id);
        //    if (material == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", material.UserId);
        //    return View(material);
        //}

        //// POST: Materials/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Name,UserId,Id,DateCreated,UserCreated,DateModified,UserModified")] Material material)
        //{
        //    if (id != material.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(material);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MaterialExists(material.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", material.UserId);
        //    return View(material);
        //}

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.Id == id);
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

        [HttpPost]
        public ActionResult Progress()
        {
            return this.Content(Startup.Progress.ToString());
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal) + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            string pathD = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "materials");

            if (!Directory.Exists(pathD))
                Directory.CreateDirectory(pathD);
            //string path = this.hostingEnvironment.WebRootPath + "\\images\\materials\\";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "materials", filename);

            return path;
        }
    }
}
