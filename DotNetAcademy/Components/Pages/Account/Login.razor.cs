using DotNetAcademy.Models;
using DotNetAcademy.Persistence.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DotNetAcademy.Components.Pages.Account;

public partial class Login
{
	[Inject]
	private SignInManager<ApplicationUser> SignInManager { get; set; } = default!;

	[Inject]
	private NavigationManager Navigation { get; set; } = default!;

	[Inject]
	private AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

	[SupplyParameterFromForm]
	private LoginModel Input { get; set; } = new();

	private string? errorMessage;

	protected override async Task OnInitializedAsync()
	{
		var authState = await AuthStateProvider.GetAuthenticationStateAsync();
		if (authState.User.Identity?.IsAuthenticated == true)
		{
            Navigation.NavigateTo("/");
        }
	}

	private async Task HandleLogin()
	{
		var result = await SignInManager.PasswordSignInAsync(
			Input.Email,
			Input.Password,
			Input.RememberMe,
			lockoutOnFailure: false);

		if (result.Succeeded)
		{
			Navigation.NavigateTo("/", forceLoad: true);
		}
		else
		{
			errorMessage = "Invalid login attempt.";
		}
	}
}