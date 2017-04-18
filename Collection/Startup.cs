using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Collection.Models;
using Microsoft.EntityFrameworkCore;
using Collection.Repositories;

namespace Collection
{
    public class Startup
    {
        private string _contentRootPath;

        public IConfigurationRoot _Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            _Configuration = builder.Build();

            _contentRootPath = env.ContentRootPath;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            string conn = _Configuration.GetConnectionString("DefaultConnection");
            if (conn.Contains("%CONTENTROOTPATH%"))
            {
                conn = conn.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }

            // Database
            services.AddDbContext<ToyContext>(options => options.UseSqlServer(conn));

            // MVC
            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession();

            // Services - Dependency Injection
            services.AddTransient<IToyRepository, ToyRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory log, ToyContext context)
        {
            if (env.IsDevelopment())
            {
                log.AddDebug(LogLevel.Information);
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(r =>
                r.MapRoute(
                name: "default",
                template: "{controller=Toys}/{action=Collection}/{id?}"
                ));

            ToyInitializer.Initialize(context);
        }
    }
}
