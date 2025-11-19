using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using DotNetAcademy.Services.Dto;
using DotNetAcademy.Services.ItemService;

namespace DotNetAcademy.Services.ItemsService;

public class ItemService(IItemRepository itemRepository) : IItemService
{
    public async Task AddItemAsync(AddItemInfo itemInfo)
	{
		var item = new Item()
		{
			MediaType = itemInfo.MediaType,
			Title = itemInfo.Title,
			Description = itemInfo.Description,
			Poster = itemInfo.Poster,
			Rating = itemInfo.Rating,
			Images = [..itemInfo.Images.Select(img => new ItemImage { Data = img })],
			ReleaseDate = itemInfo.ReleaseDate,
			Genre = itemInfo.Genre
		};

		await itemRepository.AddItemAsync(item);
	}
}