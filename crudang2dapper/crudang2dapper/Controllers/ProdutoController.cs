using Crudang2dapper.DAL;
using Crudang2dapper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crudang2dapper.Controllers
{
    [Produces("application/json")]
    [Route("api/Produto")]
    public class ProdutoController : Controller
    {
        private IProdutoDAL produtoDAL;

        public ProdutoController(IProdutoDAL _prodDal)
        {
            this.produtoDAL = _prodDal;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
            try
            {
                return await this.produtoDAL.GetProdutos();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Produto> Get(int id)
        {
            return await this.produtoDAL.GetProduto(id);
        }

        [HttpPost]
        public async Task Post([FromBody]Produto produto)
        {
            await this.produtoDAL.AdicionaProduto(produto);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Produto produto)
        {
            await this.produtoDAL.AtualizaProduto(produto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.produtoDAL.DeletaProduto(id);
        }
    }
}
