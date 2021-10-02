using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [Column(TypeName = "VARCHAR(200)")]
        public string Nombre { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "El campo Identificacion es requerido.")]
        [Column(TypeName = "VARCHAR(20)")]
        public string Identificacion { get; set; }
    }
}
