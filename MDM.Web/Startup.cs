using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MDM.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Services.Email;
using MDM.Helper;
using MDM.Services;
using Microsoft.AspNetCore.Http.Features;

namespace MDM
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
            services.AddDbContext<DB>(options => options.UseMySql(Configuration.GetConnectionString("ClientDBContext")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8; 
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedAccount = true;
                options.User.AllowedUserNameCharacters =
               "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<DB>().AddDefaultTokenProviders().AddDefaultUI();



            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            services.AddTransient<IEmailCreator, EmailCreator>();
            services.AddTransient<IActivity, Activity>();
            services.AddTransient<IEmailSender, EmailSender>(i =>
                 new EmailSender(
                     Configuration["EmailSender:Host"],
                     Configuration.GetValue<int>("EmailSender:Port"),
                     Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                     Configuration["EmailSender:UserName"],
                     Configuration["EmailSender:Password"]
                 )
             );

            services.AddAuthorization(options =>
            {
                options.AddPolicy(MDMPolicies.AllowSuperUser, policy => policy.RequireClaim(MDMClaimTypes.SuperUser, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowAdminUser, policy => policy.RequireClaim(MDMClaimTypes.AdminUser, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowSetUp, policy => policy.RequireClaim(MDMClaimTypes.SetUp));
                options.AddPolicy(MDMPolicies.AllowSetupDelete, policy => policy.RequireClaim(MDMClaimTypes.SetUp, MDMClaimValues.Delete));
                options.AddPolicy(MDMPolicies.AllowSetupUpdate, policy => policy.RequireClaim(MDMClaimTypes.SetUp, MDMClaimValues.Update));
                options.AddPolicy(MDMPolicies.AllowToViewReports, policy => policy.RequireClaim(MDMClaimTypes.Report, MDMClaimValues.Access));
            });



            services.AddHostedService<MDMDailySchedulerService>();
            services
                 .AddMvc()
                 .AddRazorPagesOptions(options =>
                 {
                     options.Conventions.AuthorizeFolder("/Admin");
                     options.Conventions.AuthorizeFolder("/Manage");
                     options.Conventions.AuthorizeFolder("/Reports");
                     options.Conventions.AuthorizeFolder("/Member");
                     options.Conventions.AuthorizePage("/Index");
                     options.Conventions.AllowAnonymousToFolder("/Apply");
                     //options.Conventions.AddPageRoute("/Account/Login", "");
                 });

            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // using (var serviceScope = app.ApplicationServices.CreateScope())
            // {
            //     var context = serviceScope.ServiceProvider.GetService<DB>();
            //     context.Database.Migrate();
            // }

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

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/NotFound";
                    await next();
                }
            });

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
