using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson05
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<Lesson05.Models.AppDbContext>(
                options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));
            services
               .AddAuthentication("UserSecurity")
               .AddCookie("UserSecurity",
                   options =>
                   {
                       options.LoginPath = "/Account/Login/";
                       options.AccessDeniedPath = "/Account/Forbidden/";
                   });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ShirtOrder}/{action=Index}/{id?}");
            });
        }
    }
}
