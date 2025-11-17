using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Services.Dto;
using System.Runtime.CompilerServices;
using System.Linq;

namespace DotNetAcademy.Models.Mappings;

public static class ItemMappingExtensions
{
	public static List<ItemModel> ToModelList(this ListItemsInfo items)
	{
		return [..items.PageItems
			.Select(item => new ItemModel
			{
				Id	= item.Id,
				Poster = item.Poster,
				Title = item.Title,
				ReleaseDate = item.ReleaseDate,
				Genre = item.Genre,
				Rating = item.Rating
			})];
	}
}
