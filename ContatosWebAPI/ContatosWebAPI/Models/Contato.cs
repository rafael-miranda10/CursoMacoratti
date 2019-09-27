using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContatosWebAPI.Models
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required(ErrorMessage ="Informe o nome do contato")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o email do contato")]
        [StringLength(200)]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string email { get; set; }
        [Required(ErrorMessage = "Informe o telefone do contato")]
        [StringLength(20)]
        public string Telefone { get; set; }
    }
}
