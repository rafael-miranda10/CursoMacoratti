using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Identity_AutenticaAutoriza.Data;
using Identity_AutenticaAutoriza.Models;
using Identity_AutenticaAutoriza.Services;

namespace Identity_AutenticaAutoriza
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // o codigo abaixo exemplifica como customizar o padrão de senha 
                //solicitado pelo identity. Atenção, isso pode deixar os critérios
                //farcos e fragilizando a aplicação - isso acontece abaixo

                //politica de senha

                //options.Password.RequiredLength = 10;
                //options.Password.RequireLowercase = false;
                //options.Password.RequireUppercase = false;
                //options.Password.RequireNonAlphanumeric = false;

                //bloqueio de usuário

                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                //options.Lockout.MaxFailedAccessAttempts = 3;
                //options.Lockout.AllowedForNewUsers = true;

                //configurações de login

                //options.SignIn.RequireConfirmedEmail = true;
                //options.SignIn.RequireConfirmedPhoneNumber = true;

                //configurações de validação do usuário
                //options.User.RequireUniqueEmail = true;
                //options.User.AllowedUserNameCharacters = "abacdef"; //<- aqui deve-se informar todos os caracteres permitos para a senha

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //definições de cookie
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "Nome desejado";
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.Expiration = TimeSpan.FromMinutes(30);
            //});


            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppID"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
