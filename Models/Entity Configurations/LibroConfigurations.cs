using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaAPI.Models.Entity_Configurations
{
    public class LibroConfigurations: IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {

            // Para añadir la llave foranea como indice en la tabla
            builder.HasIndex(l => l.CategoriaId)
                   .HasDatabaseName("IDX_LibroCategoria");

            // Indica que tiene una categoria, y que una categoria puede tener muchos productos
            // Tambien valida que no se puede borrar una categoria si hay un producto que tenga dicha categoria.
            builder.HasOne(l => l.Categoria)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
