using IngelecDroguerries.Models;
using IngelecDroguerries.Models.Reposotories;
using IngelecStage.Data;
using IngelecStage.Service;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecStage
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
            services.AddMvc().AddRazorPagesOptions(options => {
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                   
                   Configuration.GetConnectionString("DefaultConnection")));
           
            services.AddIdentity<IdentityUser,IdentityRole>
                (options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
           
               .AddSignInManager()
               .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddControllersWithViews();
           


            services.AddRazorPages();

            services.AddAuthorization(options => {
                options.AddPolicy("readpolicy",
                    builder => builder.RequireRole("distrubuteur")); 
                options.AddPolicy("writepolicy",
                    builder => builder.RequireRole("admin"));
                options.AddPolicy("policy",
                    builder => builder.RequireRole("droguerrie"));
            });
            services.AddMvc();
                services.AddScoped<IDroguerrieDestributeur<Destributeur>, DestributeurDbRepository>();
                services.AddScoped<IDroguerrieDestributeur<Drouguerrie>, DroguerrieDbRepository>();
                services.AddDbContext<DroguerieDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            }
            

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                endpoints.MapRazorPages();
            });
        }
    }
}
