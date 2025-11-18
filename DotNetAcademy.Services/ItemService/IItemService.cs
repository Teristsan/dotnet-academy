using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ItemService;

public interface IItemService
{
	Task<int> CountItemsAsync(string mediaTypeString);
	Task<ListItemsInfo> GetPaginatedItemsAsync(int pageNumber, int pageSize, string mediaType);
	Task<ListItemDetails> GetItemDetailsByIdAsync(int id);
    Task AddItemAsync(AddItemInfo itemInfo);
	Task DeleteItemAsync(int id);
}