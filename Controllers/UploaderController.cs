using System;
using System.Collections.Generic;
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

            long totalBytes = files.Sum(f => f.Length);

            foreach (IFormFile source in files)
            {
                if (isFileImage(source))
                {
                    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');

                    filename = this.EnsureCorrectFilename(filename);

                    string materialName = filename.Split(".")[0];

                    string serverFilePath = this.GetPathAndFilename(filename);

                    byte[] buffer = new byte[16 * 1024];

                    using (FileStream output = System.IO.File.Create(serverFilePath))
                    {
                        using (Stream input = source.OpenReadStream())
                        {

                            try
                            {
                                await _context.AddAsync(new Material()
                                {
                                    Name = materialName,
                                    ImageUrl = "/images/materials/" + filename,
                                    User = await _userManager.GetUserAsync(HttpContext.User),
                                    Type = type
                                });

                                await _context.SaveChangesAsync();
                            }
                            finally
                            {
                                long totalReadBytes = 0;
                                int readBytes;



                                while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    await output.WriteAsync(buffer, 0, readBytes);
                                    totalReadBytes += readBytes;
                                    Startup.Progress = (int)((float)totalReadBytes / (float)totalBytes * 100.0);
                                    //await Task.Delay(10); // It is only to make the process slower
                                }
                            }
                        }
                    }
                }
            }

            ViewBag.Success = $"{Startup.Progress}個のファイルがアップロードされました。";
            return RedirectToAction("Index", "Materials");

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
            string path = this.hostingEnvironment.WebRootPath + "\\images\\materials\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }
    }
}