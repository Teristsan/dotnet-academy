using DotNetAcademy.Models;
using DotNetAcademy.Persistence.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace DotNetAcademy.Components.Pages.Account;

public partial class Register
{
	[Inject]
	private UserManager<ApplicationUser> UserManager { get; set; } = default!;

	[Inject]
	private SignInManager<ApplicationUser> SignInManager { get; set; } = default!;

	[Inject]
	private NavigationManager Navigation { get; set; } = default!;

	[SupplyParameterFromForm]
	private RegisterModel Input { get; set; } = new();

	private string? errorMessage;

	private async Task HandleRegister()
	{
		var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
		var result = await UserManager.CreateAsync(user, Input.Password);

		if (result.Succeeded)
		{
			await SignInManager.SignInAsync(user, isPersistent: false);
			Navigation.NavigateTo("/");
		}
		else
		{
			errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
		}
	}
}
