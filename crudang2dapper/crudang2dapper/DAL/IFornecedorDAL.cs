using Crudang2dapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crudang2dapper.DAL
{
    public interface IFornecedorDAL
    {
        Task<IEnumerable<Fornecedor>> GetFornecedores();
        Task<Fornecedor> GetFornecedor(int id);
        Task AdicionaFornecedor(Fornecedor fornecedor);
        Task AtualizaFornecedor(Fornecedor fornecedor);
        Task DeletaFornecedor(int id);
    }
}
