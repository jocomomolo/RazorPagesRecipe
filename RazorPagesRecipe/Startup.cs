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
using RazorPagesRecipe.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RazorPagesRecipe
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
            services.AddRazorPages();
            
            //Set custom default page
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Recipes/Index", "");
            });
            services.AddMvc();
            // keeps the casing to that of the model when serializing to json (default is converting to camelCase)
            //services.AddMvc()
            //    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            //services.AddDbContext<RazorPagesRecipeContext>(options =>
            //        options.UseNpgsql(Configuration.GetConnectionString("RazorPagesRecipeContext")));
            services.AddDbContext<RazorPagesRecipeContext>(o => o.UseNpgsql(Configuration.GetConnectionString("RazorPagesRecipeContext"),
                    options => options.SetPostgresVersion(new Version(9, 6))));
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczMjE0QDMxMzgyZTMxMmUzMFlLQ0dQODduV3Z3dmRVT0VWWUt5MVN0L0hQK0VONDJKV2phZTdudkVFbDQ9");
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
