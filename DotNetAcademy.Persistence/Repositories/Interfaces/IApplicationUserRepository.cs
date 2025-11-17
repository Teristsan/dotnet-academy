using DotNetAcademy.Persistence.Entities;

namespace DotNetAcademy.Persistence.Repositories.Interfaces;

public interface IApplicationUserRepository
{
    Task<ApplicationUser?> GetUserByIdAsync(string id);
    Task UpdateUserFieldsAsync(ApplicationUser user);
}
