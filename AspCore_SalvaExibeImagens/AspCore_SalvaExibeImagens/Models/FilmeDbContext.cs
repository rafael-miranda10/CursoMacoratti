using Microsoft.EntityFrameworkCore;

namespace AspCore_SalvaExibeImagens.Models
{
    public class FilmeDbContext : DbContext
    {
        public FilmeDbContext(DbContextOptions<FilmeDbContext> options) : base(options)
        { }

        public DbSet<Filme> Filmes { get; set; }
    }
}
