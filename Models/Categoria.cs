using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El campo NombreCategoria es requerido.")]
        [Column(TypeName = "VARCHAR(100)")]
        public string NombreCategoria { get; set; }
    }
}
