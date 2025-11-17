using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Services.ApplicationUserService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DotNetAcademy.Components;

public partial class Header
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    private SignInManager<ApplicationUser> SignInManager { get; set; } = default!;

    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Inject]
    private IApplicationUserService ProfilePictureService { get; set; } = default!;

    private string profileImageUrl = "/images/default-avatar.png";

    protected override async Task OnInitializedAsync()
    {
        await LoadProfilePicture();
    }

    private async Task LoadProfilePicture()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            var userId = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userId))
            {
                var profilePicture = await ProfilePictureService.GetProfilePicture(userId);

                if (profilePicture?.ProfileImage != null)
                {
                    var base64 = Convert.ToBase64String(profilePicture.ProfileImage);
                    profileImageUrl = $"data:image/png;base64,{base64}";
                }
            }
        }
    }

    private void Logout()
    {
        NavigationManager.NavigateTo("/logout", forceLoad: true);
    }

    private void NavigateToEditProfile()
    {
        NavigationManager.NavigateTo("/editprofile");
    }
    private void NavigateToAddItem()
    {
		NavigationManager.NavigateTo("/additem");
	}
}
