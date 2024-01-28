using curso_02_FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace curso_02_FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Sessao>()
                .HasKey(x => new { x.FilmeId, x.CinemaId });

            b.Entity<Sessao>()
                .HasOne(x => x.Cinema)
                .WithMany(c => c.Sessoes)
                .HasForeignKey(x => x.CinemaId);

            b.Entity<Sessao>()
                .HasOne(x => x.Filme)
                .WithMany(f => f.Sessoes)
                .HasForeignKey(x => x.FilmeId);

            b.Entity<Endereco>()
                .HasOne(x => x.Cinema)
                .WithOne(x => x.Endereco)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(b);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}