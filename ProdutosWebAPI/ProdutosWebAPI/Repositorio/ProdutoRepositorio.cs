using ProdutosWebAPI.Models;
using System;
using System.Collections.Generic;

namespace ProdutosWebAPI.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();
        private int _nextId = 1;

        public ProdutoRepositorio()
        {
            Add(new Produto { Nome = "Guaraná Antartica", Categoria = "Refrigerantes", Preco = 4.99M });
            Add(new Produto { Nome = "Suco de Laranja Prats", Categoria = "Sucos", Preco = 5.68M });
            Add(new Produto { Nome = "Mostarda Hammer", Categoria = "Condimentos", Preco = 3.90M });
            Add(new Produto { Nome = "Molho de Tomate Elefante", Categoria = "Condimentos", Preco = 2.99M });
            Add(new Produto { Nome = "Suco de Uva Prats", Categoria = "Sucos", Preco = 6.68M });
        }

        public Produto Add(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentException("item");
            }

            item.Id = _nextId++;
            produtos.Add(item);
            return item;
        }

        public Produto Get(int id)
        {
            return produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public void Remove(int id)
        {
            produtos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentException("item");
            }
            var index = produtos.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            produtos.RemoveAt(index);
            produtos.Add(item);
            return true;
        }
    }
}
