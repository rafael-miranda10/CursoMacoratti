using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tarefawebapi.Models
{
    [Table("Tarefas")]
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Informe o nome da tarefa")]
        [StringLength(100)]
        public string Nome { get; set; }
        public bool  IsCompleta { get; set; }
    }
}