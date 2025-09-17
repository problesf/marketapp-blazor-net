using System.ComponentModel.DataAnnotations;

namespace QP.BlazorWebApp.Application.Features.Products.Model
{
    public class ProductEditModel
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(64, ErrorMessage = "Máximo 64 caracteres")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(120, ErrorMessage = "Máximo 120 caracteres")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(1000, ErrorMessage = "Máximo 1000 caracteres")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0, Double.MaxValue, ErrorMessage = "Debe ser >= 0")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser >= 0")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "La taxrate es obligatoria")]
        [Range(0, 100, ErrorMessage = "0 a 100")]
        public double? TaxRate { get; set; }

        [Required(ErrorMessage = "La divisa es obligatoria")]
        public string? Currency { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
