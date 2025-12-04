using System.ComponentModel.DataAnnotations;

namespace DotNetAcademy.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}