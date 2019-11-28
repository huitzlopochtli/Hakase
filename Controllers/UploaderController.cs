using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using WebApplication1.Data;
using WebApplication1.Models;
using Type = WebApplication1.Models.Type;

namespace WebApplication1.Controllers
{
    public class UploaderController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UploaderController(IHostingEnvironment hostingEnvironment, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.hostingEnvironment = hostingEnvironment;
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(IList<IFormFile> files,Type type)
        {
            Startup.Progress = 0;


            foreach (IFormFile source in files)
            {
                if (isFileImage(source))
                {
                    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');

                    filename = this.EnsureCorrectFilename(filename);

                    string materialName = filename.Split(".")[0];

                    string serverFilePath = this.GetPathAndFilename(filename);

                    try
                    {
                        await source.CopyToAsync(new FileStream(serverFilePath, FileMode.Create));
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


                            await _context.AddAsync(new Material()
                            {
                                Name = materialName,
                                ImageUrl = "/images/materials/" + filename,
                                ImageThumbnailUrl1 = "/images/materials/thumbnailUrl1" + filename,
                                ImageThumbnailUrl2 = "/images/materials/thumbnailUrl2" + filename,
                                ImageThumbnailUrl3 = "/images/materials/thumbnailUrl3" + filename,
                                ImageThumbnailUrl4 = "/images/materials/thumbnailUrl4" + filename,
                                User = await _userManager.GetUserAsync(HttpContext.User),
                                Type = type
                            });

                            await _context.SaveChangesAsync();
                        }
                        catch { }
                        
                    }
                }

            }

            return Content("Success");

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
            //string path = this.hostingEnvironment.WebRootPath + "\\images\\materials\\";
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images/materials/", filename);

            return path;
        }
    }
}