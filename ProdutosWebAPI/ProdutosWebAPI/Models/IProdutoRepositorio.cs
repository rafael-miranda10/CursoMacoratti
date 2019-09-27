using System.Collections.Generic;

namespace ProdutosWebAPI.Models
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> GetAll();
        Produto Get(int id);
        Produto Add(Produto item);
        bool Update(Produto item);
        void Remove(int id);
    }
}
