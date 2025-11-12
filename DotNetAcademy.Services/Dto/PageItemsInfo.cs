using DotNetAcademy.Persistence.Entities;

namespace DotNetAcademy.Services.Dto;

public record PageItemsInfo(IEnumerable<Item> Items, int TotalItems);