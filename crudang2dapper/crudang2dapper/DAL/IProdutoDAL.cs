using Crudang2dapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crudang2dapper.DAL
{
    public interface IProdutoDAL
    {
        Task<IEnumerable<Produto>> GetProdutos();
        Task<Produto> GetProduto(int id);
        Task AdicionaProduto(Produto produto);
        Task AtualizaProduto(Produto produto);
        Task DeletaProduto(int id);
    }
}
