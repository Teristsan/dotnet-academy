using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetAcademy.Persistence.Repositories;

public class ItemRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory) : IItemRepository
{
	public async Task<Item?> GetItemByIdAsync(int id)
	{
		using var context = dbContextFactory.CreateDbContext();

		var item = await context.Items.FirstOrDefaultAsync(item => item.Id == id);

		return item;
	}

	public async Task<IEnumerable<Item>> GetAllItemsAsync()
	{
		using var context = dbContextFactory.CreateDbContext();

		var items = await context.Items.ToListAsync();
		return items;
	}

	public async Task<IEnumerable<Item>> GetPaginatedItemsAsync(int pageNumber, int pageSize)
	{
		using var context = dbContextFactory.CreateDbContext();

		var items = await context.Items
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();

		return items;
	}

	public async Task<int> CountItemsAsync()
	{
		using var context = dbContextFactory.CreateDbContext();
		return await context.Items.CountAsync();
	}

	public async Task AddItemAsync(Item item)
	{
		using var context = dbContextFactory.CreateDbContext();

		await context.AddAsync(item);
		await context.SaveChangesAsync();
	}

	public async Task DeleteItemAsync(Item item)
	{
		using var context = dbContextFactory.CreateDbContext();

		context.Items.Remove(item);
		await context.SaveChangesAsync();
	}
}
