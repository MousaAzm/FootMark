using FootMark.Application.Interfaces.Contexts;
using FootMark.Application.Interfaces.Services.Users;
using FootMark.Core.Entities.Users;
using FootMark.Infrastructure.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootMark.Web
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
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IFootMarkDbContext, FootMarkDbContext>();

            services.AddDbContext<FootMarkDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("FootMarkConnection")));

            services.AddDefaultIdentity<AppUser>()
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<FootMarkDbContext>()
             .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            options.LoginPath = "/Account/Login");

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
