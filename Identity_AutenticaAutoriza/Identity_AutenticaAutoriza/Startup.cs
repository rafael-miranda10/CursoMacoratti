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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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

            CreateRoles(serviceProvider);

        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            Task<IdentityResult> roleResultado;
            string email = "admin@admin.net";

            //verifique se existe um perfil Administrator e o cria se não existir
            Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrador");
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                roleResultado = roleManager.CreateAsync(new IdentityRole("Administrator"));
                roleResultado.Wait();
            }

            //verifica se o usuário admin existe e o cria se não existir
            //e a seguir o incluir no perfil Admin
            Task<ApplicationUser> testeUser = userManager.FindByEmailAsync(email);
            testeUser.Wait();


            if (testeUser.Result == null)
            {
                ApplicationUser administrator = new ApplicationUser();
                administrator.Email = email;
                administrator.UserName = email;

                Task<IdentityResult> novoUsuario = userManager.CreateAsync(administrator, "Amdk@1990");
                novoUsuario.Wait();

                if (novoUsuario.Result.Succeeded)
                {
                    Task<IdentityResult> novoUsuarioRole = userManager.AddToRoleAsync(administrator, "Administrator");
                    novoUsuarioRole.Wait();
                }
            }
        }
    }
}
