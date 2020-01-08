using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder #(args).UseUrls("http://localhost:5080").Build().Run();
            var host = CreateWebHostBuilder(args).UseUrls("http://localhost:5080").Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.Migrate();
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 5080); //HTTP port
                    options.Limits.MaxRequestBodySize = long.MaxValue;
                })
                //.UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
    }
}