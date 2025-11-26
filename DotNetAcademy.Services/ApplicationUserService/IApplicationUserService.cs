using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ApplicationUserService;

public interface IApplicationUserService
{
    Task<ProfilePicture> GetProfilePicture(string userId);
}
