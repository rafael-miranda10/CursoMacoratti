using Crudang2dapper.DAL;
using Crudang2dapper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crudang2dapper.Controllers
{
    [Produces("application/json")]
    [Route("api/Categoria")]
    public class CategoriaController : Controller
    {
        private ICategoriaDAL categoriaDAL;

        public CategoriaController(ICategoriaDAL _catDAL)
        {
            this.categoriaDAL = _catDAL;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await this.categoriaDAL.GetCategorias();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<Categoria> Get(int id)
        {
            return await this.categoriaDAL.GetCategoria(id);
        }
        
        // POST: api/Categoria
        [HttpPost]
        public async Task Post([FromBody]Categoria oCategoria)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);
            //if (oCategoria == null)
            //    return NotFound();

            await this.categoriaDAL.AdicionaCategoria(oCategoria);
        }
        
        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Categoria oCategoria)
        {
            await this.categoriaDAL.AtualizaCategoria(oCategoria);
        }
        
        // DELETE: api/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.categoriaDAL.DeletaCategoria(id);
        }
    }
}
