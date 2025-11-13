using System.ComponentModel.DataAnnotations;

namespace DotNetAcademy.Models;

public class LoginModel
{
	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid email format")]
	public string Email { get; set; } = "";

	[Required(ErrorMessage = "Password is required")]
	[StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters")]
	[RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain at least one uppercase letter and one number")]
	public string Password { get; set; } = "";

	public bool RememberMe { get; set; }
}
