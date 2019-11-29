using AspCore_SalvaExibeImagens.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_SalvaExibeImagens.Controllers
{
    public class FilmesController : Controller
    {
        FilmeDbContext _context;
        public FilmesController(FilmeDbContext contexto)
        {
            _context = contexto;
        }

        //GET
        public IActionResult Index()
        {
            var filmes = _context.Filmes.ToList();
            return View(filmes);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Filme filmes, List<IFormFile> Imagem)
        {
            foreach (var item in Imagem)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        filmes.Imagem = stream.ToArray();
                    }
                }
            }
            _context.Filmes.Add(filmes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileStreamResult ExibirImagem(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream(filme.Imagem);
            return new FileStreamResult(ms, "image/jpeg");
        }
    }
}