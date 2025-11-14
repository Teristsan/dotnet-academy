using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using DotNetAcademy.Services.Dto;
using DotNetAcademy.Services.ItemService;

namespace DotNetAcademy.Services.ItemsService;

public class ItemService(IItemRepository itemRepository) : IItemService
{
	public async Task<int> CountItemsAsync()
	{
		var itemsCount = await itemRepository.CountItemsAsync();
		return itemsCount;
	}

	public async Task<ListItemsInfo> GetPaginatedItemsAsync(int pageNumber, int pageSize, string mediaType)
	{
		var items = await itemRepository.GetPaginatedItemsAsync(pageNumber, pageSize, mediaType);
		var pageItems = items.Select(item => new ItemInfo(
			item.Poster,
			item.Title,
			item.ReleaseDate,
			item.Genre,
			item.Rating
		)).ToList();

		return new ListItemsInfo(pageItems);
	}

	public async Task AddItemAsync(AddItemInfo itemInfo)
	{
		var item = new Item()
		{
			MediaType = itemInfo.MediaType,
			Title = itemInfo.Title,
			Description = itemInfo.Description,
			Poster = itemInfo.Poster,
			Rating = (int)itemInfo.Rating,
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