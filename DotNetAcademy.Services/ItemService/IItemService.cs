using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ItemService;

public interface IItemService
{
	Task<int> CountItemsAsync();
	Task<ListItemsInfo> GetPaginatedItemsAsync(int pageNumber, int pageSize, string mediaType);
	Task AddItemAsync(AddItemInfo itemInfo);
	Task DeleteItemAsync(int id);
}