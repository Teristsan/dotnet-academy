using DotNetAcademy.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetAcademy.Persistence.Repositories.Interfaces;

public interface IItemRepository
{
	Task<Item?> GetItemByIdAsync(int id);
	Task<IEnumerable<Item>> GetAllItemsAsync();
	Task<IEnumerable<Item>> GetPaginatedItemsAsync(int pageNumber, int pageSize, string mediaType);
	Task<int> CountItemsAsync(string mediaTypeString);
	Task AddItemAsync(Item item);
	Task DeleteItemAsync(Item item);
}
