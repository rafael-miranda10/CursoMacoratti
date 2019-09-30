using Microsoft.AspNetCore.Mvc;

namespace ContatosWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}