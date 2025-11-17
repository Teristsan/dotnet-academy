using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetAcademy.Persistence.Repositories;

public class ApplicationUserRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory) : IApplicationUserRepository
{
    public async Task<ApplicationUser?> GetUserByIdAsync(string id)
    {
        using var context = dbContextFactory.CreateDbContext();
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task UpdateUserFieldsAsync(ApplicationUser user)
    {
        using var context = dbContextFactory.CreateDbContext();
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
}