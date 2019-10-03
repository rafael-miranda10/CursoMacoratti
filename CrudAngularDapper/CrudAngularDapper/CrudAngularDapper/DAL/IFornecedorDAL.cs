using CrudAngularDapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudAngularDapper.DAL
{
    public interface IFornecedorDAL
    {
        Task<IEnumerable<Fornecedor>> GetFornecedores();
        Task<Fornecedor> GetFornecedor(int id);
        Task AdicionarFornecedor( Fornecedor fornecedor);
        Task AtualizarrFornecedor(Fornecedor fornecedor);
        Task DeletarFornecedor(int id);
    }
}
