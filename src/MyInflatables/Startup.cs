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
using MyInflatables.Models;
using Microsoft.EntityFrameworkCore;
using MyInflatables.Repositories;

namespace MyInflatables
{
    public class Startup
    {
        public IConfigurationRoot _Configuration { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath).
                AddJsonFile("settings.json", optional: true, reloadOnChange: true).
                AddEnvironmentVariables();
            _Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<ToyContext>(options => options.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection")));

            // MVC
            services.AddMvc();

            // Services - Dependency Injection
            services.AddTransient<IToyRepository, ToyRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory log, ToyContext context)
        {
            if(env.IsDevelopment())
            {
                log.AddDebug(LogLevel.Information);
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc( r => r.MapRoute("default", "{controller=Toys}/{action=Index}/{id?}"));

            ToyInitializer.Initialize(context);
        }
    }
}
