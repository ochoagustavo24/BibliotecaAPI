using BibliotecaAPI.Models.Entity_Configurations;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base (options) {}

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LibroConfigurations());

            modelBuilder.ApplyConfiguration(new PrestamoConfigurations());
        }
    }
}
