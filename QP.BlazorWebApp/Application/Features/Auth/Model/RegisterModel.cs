using System.ComponentModel.DataAnnotations;
using QP.BlazorWebApp.Application.Features.Auth.Enum;

namespace QP.BlazorWebApp.Application.Features.Auth.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato incorrecto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria.")]
        public string Password1 { get; set; }

        [Required(ErrorMessage = "Confirmación de contraseña obligatoria.")]
        [Compare(nameof(Password1), ErrorMessage = "Las contraseñas no coinciden.")]
        public string Password2 { get; set; }

        [Required(ErrorMessage = "Tipo de usuario obligatorio.")]
        public UserType UserType { get; set; }

        public string? StoreName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserType == UserType.Vendedor && string.IsNullOrWhiteSpace(StoreName))
            {
                yield return new ValidationResult(
                    "El nombre de la tienda es obligatorio para vendedores.",
                    new[] { nameof(StoreName) });
            }
        }
    }
}
