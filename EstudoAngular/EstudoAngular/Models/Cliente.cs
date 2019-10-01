using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoAngular.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [StringLength(150)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(80)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
    }
}
