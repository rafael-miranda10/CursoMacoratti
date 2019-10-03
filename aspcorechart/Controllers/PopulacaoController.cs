using aspcorechart.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspcorechart.Controllers
{
    public class PopulacaoController : Controller
    {
        public IActionResult Index()
        {  
           return View();  
        }  
        //Retorna dados JSO da população de cada estado
         public JsonResult PopulacaoGrafico() 
        {  
           var listaPopulacao = PopulacaoService.GetPopulacaoPorEstado();  
           return Json(listaPopulacao);  
        }  
    }
}