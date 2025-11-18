using DotNetAcademy.Persistence.Repositories.Interfaces;
using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ApplicationUserService;

public class ApplicationUserService(IApplicationUserRepository userRepo) : IApplicationUserService
{
    public async Task<UserInfo?> GetUserByIdAsync(string id)
    {
        var userEntity = await userRepo.GetUserByIdAsync(id);

        if (userEntity == null)
            return null;

        var user = new UserInfo(
            FirstName: userEntity.FirstName,
            LastName: userEntity.LastName,
            UserName: userEntity.UserName ?? string.Empty,
            Email: userEntity.Email ?? string.Empty,
            Description: userEntity.Description,
            ProfileImage: userEntity.ProfileImage
        );

        return user;
    }

    public async Task UpdateUserFields(UserInfo user, string userId)
    {
        // Use user.Id instead of user.UserName
        var existingUser = await userRepo.GetUserByIdAsync(userId);

        if (existingUser == null)
            return;

        // Only update fields that are not null or empty
        if (!string.IsNullOrEmpty(user.FirstName))
            existingUser.FirstName = user.FirstName;

        if (!string.IsNullOrEmpty(user.LastName))
            existingUser.LastName = user.LastName;

        if (!string.IsNullOrEmpty(user.UserName))
            existingUser.UserName = user.UserName;

        if (!string.IsNullOrEmpty(user.Email))
            existingUser.Email = user.Email;

        if (!string.IsNullOrEmpty(user.Description))
            existingUser.Description = user.Description;

        if (user.ProfileImage != null)
            existingUser.ProfileImage = user.ProfileImage;

        await userRepo.UpdateUserFieldsAsync(existingUser);
    }

    public async Task<ProfilePicture> GetProfilePicture(string userId)
    {
        var userEntity = await userRepo.GetUserByIdAsync(userId);

        return new ProfilePicture(ProfileImage: userEntity?.ProfileImage);
    }
}
