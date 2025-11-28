using DotNetAcademy.Models;
using DotNetAcademy.Persistence.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace DotNetAcademy.Components.Pages.Account
{

	public partial class Login
	{
		[Inject]
		private SignInManager<ApplicationUser> SignInManager { get; set; } = default!;

		[SupplyParameterFromForm]
		private LoginModel Input { get; set; } = new();

		private async Task HandleLogin(EditContext args)
		{
			var result = await SignInManager.PasswordSignInAsync(
				Input.Email,
				Input.Password,
				Input.RememberMe,
				lockoutOnFailure: false);
		}
	}
}
