using DotNetAcademy.Persistence.Repositories.Interfaces;
using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ApplicationUserService;

public class ApplicationUserService(IApplicationUserRepository userRepo) : IApplicationUserService
{
    public async Task<ProfilePicture> GetProfilePicture(string userId)
    {
        var userEntity = await userRepo.GetUserByIdAsync(userId);

        return new ProfilePicture(ProfileImage: userEntity?.ProfileImage);
    }
}
