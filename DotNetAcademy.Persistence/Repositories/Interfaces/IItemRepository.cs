using DotNetAcademy.Persistence.Entities;

namespace DotNetAcademy.Persistence.Repositories.Interfaces;

public interface IItemRepository
{
	Task<Item?> GetItemByIdAsync(int id);
	Task<IEnumerable<Item>> GetAllItemsAsync();
	Task<IEnumerable<Item>> GetPaginatedItemsAsync(int pageNumber, int pageSize);
	Task<int> CountItemsAsync();
	Task AddItemAsync(Item item);
	Task DeleteItemAsync(Item item);
}
