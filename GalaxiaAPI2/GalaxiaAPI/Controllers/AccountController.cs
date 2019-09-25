using GalaxiaAPI.Models;
using GalaxiaAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GalaxiaAPI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MeuUserIdentity> _userManager;
        private readonly SignInManager<MeuUserIdentity> _loginManager;
        private readonly RoleManager<MeuRoleIdentity> _roleManager;

        public AccountController(UserManager<MeuUserIdentity> userManager,
            SignInManager<MeuUserIdentity> loginManager, 
            RoleManager<MeuRoleIdentity> roleManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = _loginManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Content("Acesso Autorizado!");

                }
            }
            return View(login);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                MeuUserIdentity user = new MeuUserIdentity();
                user.UserName = register.UserName;
                user.Email = register.Email;

                IdentityResult result = _userManager.CreateAsync(user, register.Password).Result;

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        MeuRoleIdentity role = new MeuRoleIdentity();
                        role.Name = "Admin";
                        role.Descricao = "Realiza operações básicas.";

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("","Erro ao criar o perfil");
                            return View(register);
                        }
                    }

                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                    return RedirectToAction("Login", "Account");

                }
            }
            return View(register);
        }
    }
}