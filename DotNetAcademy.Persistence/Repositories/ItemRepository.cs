using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetAcademy.Persistence.Repositories;

public class ItemRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory) : IItemRepository
{
	public async Task<Item?> GetItemByIdAsync(int id)
	{
		using var context = dbContextFactory.CreateDbContext();

		var item = await context.Items
			.Include(item => item.Images)
			.AsSplitQuery()
			.AsNoTracking()
			.FirstOrDefaultAsync(item => item.Id == id);

		return item;
	}

	public async Task<IEnumerable<Item>> GetAllItemsAsync()
	{
		using var context = dbContextFactory.CreateDbContext();

		var items = await context.Items
			.AsNoTracking()
			.ToListAsync();
		return items;
	}

	public async Task<IEnumerable<Item>> GetPaginatedItemsAsync(int pageNumber, int pageSize, string mediaType)
	{
		using var context = dbContextFactory.CreateDbContext();

		var items = await context.Items
			.Where(item => item.MediaType == mediaType)
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.AsNoTracking()
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
