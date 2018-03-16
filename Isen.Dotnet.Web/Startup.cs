using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isen.Dotnet.Library.Data;
using Isen.Dotnet.Library.Repositories.DbContext;
using Isen.Dotnet.Library.Repository.InMemory;
using Isen.Dotnet.Library.Repository.Interface;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web
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
            //Utiliser Entity Framework
            services.AddDbContext<ApplicationDbContext>(options=>
            //utiliser le provider Sqlite
            options.UseSqlite(
                // Utiliser la clé DefaultConnection
                // du fichier de config
                Configuration.GetConnectionString("DefaultConnection")));
                
            services.AddMvc();
            //Injection des dependances

            //Injection des repo
            services.AddScoped<ICityRepository, DbContextCityRepository>();
            services.AddScoped<IPersonRepository, DbContextPersonRepository>();

            //injection d'autres services
            services.AddScoped<SeedData>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
        IHostingEnvironment env, 
        ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
