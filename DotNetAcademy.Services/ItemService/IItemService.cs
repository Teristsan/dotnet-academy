using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Services.Dto;

namespace DotNetAcademy.Services.ItemService;

public interface IItemService
{
    Task AddItemAsync(AddItemInfo itemInfo);
}