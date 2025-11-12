using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ItemService;

public interface IItemService
{
	Task<IEnumerable<Item>> GetAllItemsAsync();
	Task<PageItemsInfo> GetPaginatedItemsAsync(int pageNumber, int pageSize);
	Task AddItemAsync(string name, string description);
	Task DeleteItemAsync(int id);
}