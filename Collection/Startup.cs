using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
//using Collection.Infrastructure.IoC;
using Collection.Models;
using Collection.Repositories;
using Collection.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Collection
{
    public class Startup
    {
        private string _contentRootPath;
        public IConfigurationRoot Configuration { get; set; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("settings.json", optional : true, reloadOnChange : true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _contentRootPath = env.ContentRootPath;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<ToyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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

                o.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.Expiration = TimeSpan.FromDays(150);
                o.LoginPath = "/Account/Login";
                o.LogoutPath = "/Account/Logout";
                o.AccessDeniedPath = "/Account/AccessDenied";
                o.SlidingExpiration = true;
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();

            var builder = new ContainerBuilder();

            builder.Populate(services);
            //builder.RegisterModule(new ContainerModule(Configuration));

            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory log, ToyContext context)
        {
            if (env.IsDevelopment())
            {
                log.AddDebug(LogLevel.Information);
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            //app.UseIdentity();
            app.UseAuthentication();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(r =>
                r.MapRoute(
                    name: "default",
                    template: "{controller=blog}/{action=index}/{id?}"
                ));

            ToyInitializer.Initialize(context);
        }
    }
}