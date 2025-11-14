using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using DotNetAcademy.Services.Dto;
using DotNetAcademy.Services.ItemService;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Reflection;

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

	public async Task AddItemAsync(AddItemInfo itemInfo)
	{
		var item = new Item()
		{
			MediaType = itemInfo.MediaType,
			Title = itemInfo.Title,
			Description = itemInfo.Description,
			Poster = itemInfo.Poster,
			Images = [..itemInfo.Images.Select(img => new ItemImage { Data = img })],
			ReleaseDate = itemInfo.ReleaseDate,
			Genre = itemInfo.Genre
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