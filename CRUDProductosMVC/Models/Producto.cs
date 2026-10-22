
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDProductosMVC.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es obligatorio.")]
        [StringLength(12, ErrorMessage = "El código no puede superar los 12 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(80, MinimumLength = 3,
            ErrorMessage = "El nombre debe tener entre 3 y 80 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [StringLength(40, ErrorMessage = "La categoría no puede superar los 40 caracteres.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 999999999999999,
      ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }

        [Range(0, 9999,
            ErrorMessage = "La existencia debe estar entre 0 y 9999.")]
        public int Existencia { get; set; }

        public bool Activo { get; set; } = true;
    }
}
