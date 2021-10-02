using BibliotecaAPI.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Categoria Categoria { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [Column(TypeName = "VARCHAR(200)")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo CategoriaId es requerido.")]
        public int CategoriaId { get; set; }

    }
}
