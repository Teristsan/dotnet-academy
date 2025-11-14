using DotNetAcademy.Persistence.Entities;
using System.Runtime.CompilerServices;

namespace DotNetAcademy.Models.Mappings;

public static class ItemMappingExtensions
{
	public static ItemModel ToModel(this Item item)
	{
		return new ItemModel
		{
			MediaType = item.MediaType!,
			Title = item.Title!,
			Description = item.Description!,
			Poster = item.Poster,
			Rating = item.Rating,
			Images = item.Images.Select(img => img.Data).ToList()
		};
	}

	public static List<ItemModel> ToModelList(this IEnumerable<Item> items)
	{
		return [..items.Select(item => item.ToModel())];
	}
}
