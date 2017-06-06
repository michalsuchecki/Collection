using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


using Collection.Repositories;
using Collection.Models;
using Collection.Services;



namespace Collection
{
    public class Usr
    {

    }

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

            // Identities
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ToyContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequiredLength = 8;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;

                o.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(30);
                o.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                o.Cookies.ApplicationCookie.LogoutPath = "/Account/Logout";

                o.User.RequireUniqueEmail = true;

            });

            // MVC
            services.AddMvc();

            services.AddAuthorization(options => options.AddPolicy("modify", policy => policy.RequireRole("Administrator")));

            services.AddDistributedMemoryCache();
            services.AddSession();

            // Services - Dependency Injection
            services.AddTransient<IToyRepository, ToyRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();
            services.AddTransient<IPostRepository, PostRepository>();

            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory log, ToyContext context)
        {
            if (env.IsDevelopment())
            {
                log.AddDebug(LogLevel.Information);
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseIdentity();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(r =>
                r.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}"
                ));

            ToyInitializer.Initialize(context);
        }
    }
}
