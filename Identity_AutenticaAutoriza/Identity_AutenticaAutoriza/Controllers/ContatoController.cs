using System.Linq;
using Identity_AutenticaAutoriza.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity_AutenticaAutoriza.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {

        private ApplicationDbContext _contexto;

        public ContatoController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
       
        public IActionResult Index()
        {
            var contatos = _contexto.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult AcessoAutorizado()
        {
            return Content("Acesso Autorizado!");
        }

        [AllowAnonymous]
        public IActionResult AcessoAnonimo()
        {
            return Content("Acesso Anonimo!");
        }
    }
}