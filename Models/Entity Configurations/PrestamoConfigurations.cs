using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaAPI.Models.Entity_Configurations
{
    public class PrestamoConfigurations: IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {

            // Para añadir la llave foranea como indice en la tabla
            builder.HasIndex(l => l.UsuarioId)
                   .HasDatabaseName("IDX_PrestamoUsuario");

            builder.HasIndex(l => l.LibroId)
                   .HasDatabaseName("IDX_PrestamoLibro");

            // Indica que tiene una categoria, y que una categoria puede tener muchos productos
            // Tambien valida que no se puede borrar una categoria si hay un producto que tenga dicha categoria.
            builder.HasOne(l => l.Usuario)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Libro)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
