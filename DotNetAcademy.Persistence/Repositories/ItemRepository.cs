using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetAcademy.Persistence.Repositories;

public class ItemRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory) : IItemRepository
{

	public async Task AddItemAsync(Item item)
	{
		using var context = dbContextFactory.CreateDbContext();

		await context.AddAsync(item);
		await context.SaveChangesAsync();
	}
}
