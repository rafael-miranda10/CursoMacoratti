using Microsoft.EntityFrameworkCore;

namespace EstudoAngular.Models
{
    public class EstudoContext : DbContext
    {
        public EstudoContext(DbContextOptions<EstudoContext> options) : base(options)
        {

        }

        public virtual DbSet<Cliente> Clientes { get; set; }
    }
}
