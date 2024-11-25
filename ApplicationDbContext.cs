
using Microsoft.EntityFrameworkCore;
using Just.Models;
namespace Just.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Conteudo> Conteudos { get; set; }
        public DbSet<Criador> Criadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aqui você deve colocar a sua string de conexão
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=JustStreaming;Trusted_Connection=True;");
        }
    }
}