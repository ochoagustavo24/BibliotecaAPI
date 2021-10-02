using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class Prestamo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo UsuarioId es requerido.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo LibroId es requerido.")]
        public int LibroId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Libro Libro { get; set; }

    }
}
