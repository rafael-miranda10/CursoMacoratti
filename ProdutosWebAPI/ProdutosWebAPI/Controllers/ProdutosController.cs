using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProdutosWebAPI.Models;
using ProdutosWebAPI.Repositorio;

namespace ProdutosWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        static readonly IProdutoRepositorio _produtoRepositorio = new ProdutoRepositorio();

        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepositorio.GetAll();
        }

        [HttpGet("{id}", Name ="GetProduto")]
        public IActionResult GetProductById(int id)
        {
            var produto =  _produtoRepositorio.Get(id);
            if(produto == null)
            {
                return NotFound();
            }

            return new ObjectResult(produto);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Produto produto)
        {
            if(produto == null)
            {
                return BadRequest();
            }

            produto = _produtoRepositorio.Add(produto);
            return CreatedAtRoute("GetProduto", new { id = produto.Id}, produto);
        }

        [HttpPut("{id}")]
        public IActionResult AlterProduct(int id, [FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            produto.Id = id;
            if (!_produtoRepositorio.Update(produto))
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var produto = _produtoRepositorio.Get(id);
            if(produto == null)
            {
                return NotFound();
            }
            _produtoRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}