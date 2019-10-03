namespace Crudang2dapper.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public int FornecedorId { get; set; }

        public string FornecedorNome { get; set; }

        public int CategoriaId { get; set; }

        public string CategoriaNome { get; set; }

        public System.DateTime UltimaAtualizacao { get; set; }
    }
}
