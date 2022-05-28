using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RSB_Ofish_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // Apply Auto Migration 
            using(var scope = host.Services.CreateScope())
            {

                var db = scope.ServiceProvider.GetService<RSB_Ofish_System.Data.RSB_Ofish_SystemContext>();
                var identity = scope.ServiceProvider.GetService<IdentityDbContext>();
                identity.Database.Migrate();
                
                db.Database.Migrate();
            }

            // Apply Auto Migration 
            host.Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                });
    }
}
