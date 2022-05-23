using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RSB_Ofish_System.Data;
using RSB_Ofish_System.Repository.Ofish.Services;
using RSB_Ofish_System.Repository.Ofish.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RSB_Ofish_System.Repository.Users.Service;
using RSB_Ofish_System.Repository.Users.Interface;
using Microsoft.AspNetCore.DataProtection;
using RSB_Ofish_System.Utils;
namespace RSB_Ofish_System
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddDbContext<RSB_Ofish_SystemContext>(options =>
            {

                options.UseSqlServer(Configuration.GetConnectionString("RSB_Ofish_SystemContext"));
            });

            services.AddDbContext<IdentityDbContext>(options =>

             options.UseSqlServer(Configuration.GetConnectionString("RSB_Ofish_SystemContext"),
             optionsBuilder =>

                    optionsBuilder.MigrationsAssembly("RSB_Ofish_System")

                )
            );

            services.AddScoped<IOfishService, OfishService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<Iprotector, Protector>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/AccessDenied";
                options.ExpireTimeSpan = System.TimeSpan.FromDays(1);

            });





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
