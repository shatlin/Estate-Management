using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MDM.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Identity;
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
         //   services.AddTransient <DB > (options => options.UseMySql(Configuration.GetConnectionString("DB")();
            // services.AddDbContext<DB>(options => options.UseMySql(Configuration.GetConnectionString("DB")));

            services.AddDbContext<DB>(options =>
                 options.UseMySql(Configuration.GetConnectionString("DB")),
      ServiceLifetime.Transient);

            services.AddHttpContextAccessor();
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5; 
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedAccount = true;
                options.User.AllowedUserNameCharacters =
               "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<DB>().AddDefaultTokenProviders().AddDefaultUI();

            services.AddMemoryCache();

           

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;
            });


            

            services.AddTransient<IEmailCreator, EmailCreator>();
            services.AddTransient<IActivity, Activity>();
            services.AddScoped<IEmailRecipients, EmailRecipients>();
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
                options.AddPolicy(MDMPolicies.AllowAdmin, policy => policy.RequireClaim(MDMClaimTypes.Admin, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowTrustee, policy => policy.RequireClaim(MDMClaimTypes.Trustee, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowOwner, policy => policy.RequireClaim(MDMClaimTypes.Owner, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowTenant, policy => policy.RequireClaim(MDMClaimTypes.Tenant, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowEstateManager, policy => policy.RequireClaim(MDMClaimTypes.EstateManager, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowManagingAgent, policy => policy.RequireClaim(MDMClaimTypes.ManagingAgent, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowSecurityVendor, policy => policy.RequireClaim(MDMClaimTypes.SecurityVendor, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowGardenVendor, policy => policy.RequireClaim(MDMClaimTypes.GardenVendor, MDMClaimValues.Access));
                options.AddPolicy(MDMPolicies.AllowServiceProvider, policy => policy.RequireClaim(MDMClaimTypes.ServiceProvider, MDMClaimValues.Access));
             

            });

            services.AddAntiforgery(o => o.SuppressXFrameOptionsHeader = true);
            services.AddHostedService<MDMDailySchedulerService>();
            services
                 .AddMvc()
                 .AddRazorPagesOptions(options =>
                 {
                     options.Conventions.AuthorizeFolder("/Admin");
                     options.Conventions.AuthorizeFolder("/Manage");
                     options.Conventions.AuthorizeFolder("/Reports");
                     options.Conventions.AuthorizePage("/Index");
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
