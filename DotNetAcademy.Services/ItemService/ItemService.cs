using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using DotNetAcademy.Services.Dto;
using DotNetAcademy.Services.ItemService;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DotNetAcademy.Services.ItemsService;

public class ItemService(IItemRepository itemRepository) : IItemService
{
	public async Task<IEnumerable<Item>> GetAllItemsAsync()
	{
		var items = await itemRepository.GetAllItemsAsync();
		return items;
	}

	public async Task<PageItemsInfo> GetPaginatedItemsAsync(int pageNumber, int pageSize)
	{
		var items = await itemRepository.GetPaginatedItemsAsync(pageNumber, pageSize);
		var totalItems = await itemRepository.CountItemsAsync();

		return new PageItemsInfo(items, totalItems);
	}

	public async Task AddItemAsync(string name, string description)
	{
		if (name == null || description == null)
			throw new ArgumentNullException();

		var item = new Item()
		{
			Name = name,
			Description = description
		};

		await itemRepository.AddItemAsync(item);
	}

	public async Task DeleteItemAsync(int id)
	{
		var item = await itemRepository.GetItemByIdAsync(id);

		if (item != null)
			await itemRepository.DeleteItemAsync(item);
	}
}