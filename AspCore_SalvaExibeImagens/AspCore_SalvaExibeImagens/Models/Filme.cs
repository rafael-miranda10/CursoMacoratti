using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCore_SalvaExibeImagens.Models
{
    [Table("Filmes")]
    public class Filme
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        public byte[] Imagem { get; set; }
    }
}
