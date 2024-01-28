using curso_02_FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace curso_02_FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
        {
            
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}