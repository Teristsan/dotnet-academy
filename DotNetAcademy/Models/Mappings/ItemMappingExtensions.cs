using DotNetAcademy.Persistence.Entities;
using System.Runtime.CompilerServices;

namespace DotNetAcademy.Models.Mappings;

public static class ItemMappingExtensions
{
	public static ItemModel ToModel(this Item item)
	{
		return new ItemModel
		{
			Id = item.Id,
			Name = item.Name,
			Description = item.Description,
		};
	}

	public static List<ItemModel> ToModelList(this IEnumerable<Item> items)
	{
		return [..items.Select(item => item.ToModel())];
	}
}
