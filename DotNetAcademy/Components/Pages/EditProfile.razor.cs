using DotNetAcademy.Models;
using DotNetAcademy.Services.ApplicationUserService;
using DotNetAcademy.Services.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Claims;

namespace DotNetAcademy.Components.Pages;

public partial class EditProfile
{
    [Inject]
    private AuthenticationStateProvider? AuthStateProvider { get; set; }
    [Inject] 
    private NavigationManager? NavigationManager { get; set; }
    [Inject] 
    private IApplicationUserService? UserService { get; set; }
    
    [SupplyParameterFromForm]
    private ProfileFormModel ProfileModel { get; set; } = new();

    private const long MaxFileSize = 5 * 1024 * 1024;
    private string? fileUploadMessage;
    private bool isFileUploadError;
    private string? updateMessage;
    private bool isUpdateError;

    protected override async Task OnInitializedAsync()
    {
        await LoadUserData();
    }

    private async Task LoadUserData()
    {
        var authState = await AuthStateProvider!.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated == false)
            return;
        
        var userId = user!.FindFirstValue(ClaimTypes.NameIdentifier);
            
        if (!string.IsNullOrEmpty(userId))
        {
            var userDto = await UserService!.GetUserByIdAsync(userId);
                
            if (userDto != null)
            {
                ProfileModel.FirstName = userDto.FirstName;
                ProfileModel.LastName = userDto.LastName;
                ProfileModel.UserName = userDto.UserName ?? string.Empty;
                ProfileModel.Email = userDto.Email ?? string.Empty;
                ProfileModel.Description = userDto.Description;
                ProfileModel.ProfileImage = userDto.ProfileImage;
            }
        } 
    }

    private string GetProfileImageSource()
    {
        if (ProfileModel.ProfileImage != null)
        {
            var base64 = Convert.ToBase64String(ProfileModel.ProfileImage);
            return $"data:image/jpeg;base64,{base64}";
        }
        return "/images/default-avatar.png"; 
    }

    private async Task HandleFileSelected(InputFileChangeEventArgs e)
    {
        fileUploadMessage = null;
        isFileUploadError = false;

        var file = e.File;

        if (file == null)
            return;

        // Validate file size
        if (file.Size > MaxFileSize)
        {
            fileUploadMessage = $"File size exceeds 5 MB";
            isFileUploadError = true;
            StateHasChanged();
            return;
        }

        // Validate file type
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = Path.GetExtension(file.Name).ToLowerInvariant();
        
        if (!allowedExtensions.Contains(fileExtension))
        {
            fileUploadMessage = "Only JPG, JPEG, and PNG files are allowed.";
            isFileUploadError = true;
            StateHasChanged();
            return;
        }

        try
        {
            // Read the file into a byte array
            using var memoryStream = new MemoryStream();
            await file.OpenReadStream(MaxFileSize).CopyToAsync(memoryStream);
            ProfileModel.ProfileImage = memoryStream.ToArray();

            fileUploadMessage = $"Image uploaded successfully: {file.Name} ({file.Size / 1024.0:F2} KB)";
            isFileUploadError = false;
            StateHasChanged();
        }
        catch
        {
            fileUploadMessage = $"Error uploading file";
            isFileUploadError = true;
            StateHasChanged();
        }
    }

    private async Task HandleValidSubmit()
    {
        updateMessage = null;
        isUpdateError = false;

        var authState = await AuthStateProvider!.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated == false)
            return;

        var userId = user!.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!string.IsNullOrEmpty(userId))
        {
            try
            {
                var userDto = new UserInfo(
                    FirstName: ProfileModel.FirstName,
                    LastName: ProfileModel.LastName,
                    UserName: ProfileModel.UserName,
                    Email: ProfileModel.Email,
                    Description: ProfileModel.Description,
                    ProfileImage: ProfileModel.ProfileImage
                );

                await UserService!.UpdateUserFields(userDto, userId);
                
                updateMessage = "Profile updated successfully!";
                isUpdateError = false;
                StateHasChanged();
            }
            catch
            {
                updateMessage = $"Error updating profile";
                isUpdateError = true;
                StateHasChanged();
            }
        }
    }

    private void HandleCancel()
    {
        NavigationManager!.NavigateTo("/", forceLoad:true);
    }
}
