using DotNetAcademy.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;

namespace DotNetAcademy.Components.Pages.Account;

public partial class Logout
{
	[Inject]
	private SignInManager<ApplicationUser> SignInManager { get; set; } = default!;

	[Inject]
	private NavigationManager Navigation { get; set; } = default!;

	protected override async Task OnInitializedAsync()
	{
		await SignInManager.SignOutAsync();
		Navigation.NavigateTo("/");
	}
}