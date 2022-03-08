using GBCSporting2021_ACH.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GBCSporting2021_ACH
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
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddDbContext<SportingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SportingContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "products",
                    defaults: new { controller = "Product", action = "List" });

                endpoints.MapControllerRoute(
                    name: "technician",
                    pattern: "technicians",
                    defaults: new { controller = "Technician", action = "List" });

                endpoints.MapControllerRoute(
                    name: "customer",
                    pattern: "customers",
                    defaults: new { controller = "Customer", action = "List" });

                endpoints.MapControllerRoute(
                    name: "incident",
                    pattern: "incidents",
                    defaults: new { controller = "Incident", action = "List" });

                endpoints.MapControllerRoute(
                    name: "registration",
                    pattern: "registrations",
                    defaults: new { controller = "Registration", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
