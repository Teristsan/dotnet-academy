using DotNetAcademy.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetAcademy.Persistence.Repositories.Interfaces;

public interface IItemRepository
{
	Task AddItemAsync(Item item);
}
