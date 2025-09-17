using System.ComponentModel.DataAnnotations;

namespace QP.BlazorWebApp.Application.Features.Auth.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato incorrecto")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
