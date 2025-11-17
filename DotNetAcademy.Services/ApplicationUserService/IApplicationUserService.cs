using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ApplicationUserService;

public interface IApplicationUserService
{
    Task<User?> GetUserByIdAsync(string id);
    Task UpdateUserFields(User user, string userId);
    Task<ProfilePicture> GetProfilePicture(string userId);
}
