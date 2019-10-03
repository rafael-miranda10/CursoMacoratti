using Crudang2dapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crudang2dapper.DAL
{
    public interface ICategoriaDAL
    {
        Task<IEnumerable<Categoria>> GetCategorias();

        Task<Categoria> GetCategoria(int id);

        Task AdicionaCategoria(Categoria categoria);

        Task AtualizaCategoria(Categoria categoria);

        Task DeletaCategoria(int id);
    }
}
