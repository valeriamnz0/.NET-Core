using Examen.Components;
using Examen.Contracts;
using Examen.DataAccess.Data;
using Examen.DataAccess.Repositories;
using Examen.DataAccess.Repository.UnitOfWork;
using Examen.DataAccess.Repository.UnitOfWork.Extensions;
using Examen.Models;
using Examen.Models.ConfigurationModels;
using Examen.Models.DataModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen
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
           
           services.RegisterInfrastructureServices(Configuration); //tambien

            //para login y registro
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                }

                )
                .AddCookie(
                options =>
                {
                    options.LoginPath = "/accounts/login";
                    options.LoginPath = "/accounts/logout";
                    options.AccessDeniedPath = "/accounts/accessdenied";
                    options.Cookie.SameSite = SameSiteMode.Lax;
                }
                );
                //este de AddGoogle se agrega para la configuración
               /* .AddGoogle(

                    options =>
                    {
                        options.ClientId =
                            Configuration.GetValue<string>("GoogleAuthenticationConfiguration:ClientId");
                        options.ClientSecret =
                            Configuration.GetValue<string>("GoogleAuthenticationConfiguration:ClientSecret");
                    });*/
;

            services.Configure<IdentityOptions>(
                options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 3;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireDigit = true;
                }
                );  //aquí termina lo del login y registro

            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("Default")))
                    .AddUnitOfWork<ApplicationDbContext>()
                    .AddRepository<Rol, RolRepository>()
                    .AddRepository<Cliente, ClienteRepository>()
                    .AddRepository<Empleado, EmpleadoRepository>(); 

            services.AddScoped<IApplicationDbContext>
                (options => options.GetService<ApplicationDbContext>());

            services.AddSingleton<ICartero, Cartero>();
            services.Configure<ConfiguracionSmtp>(Configuration.GetSection("ConfiguracionSmtp"));

            services.Configure<ConfiguracionRecaptcha>(Configuration.GetSection("ConfiguracionRecaptcha"));

            services.AddSingleton<IRecaptchaValidator, RecaptchaValidator>();

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy(      //uso de cookie
               new CookiePolicyOptions
               {
                   MinimumSameSitePolicy = SameSiteMode.Lax
               }
               );

            app.UseAuthorization();
            app.UseAuthentication(); //para hacer la autenticacion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
