using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ApplicationUserService;

public interface IApplicationUserService
{
    Task<UserInfo?> GetUserByIdAsync(string id);
    Task UpdateUserFields(UserInfo user, string userId);
    Task<ProfilePicture> GetProfilePicture(string userId);
}
