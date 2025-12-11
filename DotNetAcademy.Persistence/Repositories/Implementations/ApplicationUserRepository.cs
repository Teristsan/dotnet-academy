using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;

namespace DotNetAcademy.Persistence.Repositories.Implementations;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly ApplicationDbContext context;

    public ApplicationUserRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(string id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task UpdateUserFieldsAsync(ApplicationUser user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
}
