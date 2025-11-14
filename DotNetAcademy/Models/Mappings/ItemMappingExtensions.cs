using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Services.Dto;
using System.Runtime.CompilerServices;
using System.Linq;

namespace DotNetAcademy.Models.Mappings;

public static class ItemMappingExtensions
{
	public static List<GetItemModel> ToModelList(this ListItemsInfo items)
	{
		return [..items.PageItems
			.Select(item => new GetItemModel
			{
				Poster = item.Poster,
				Title = item.Title,
				ReleaseDate = item.ReleaseDate,
				Genre = item.Genre,
				Rating = item.Rating
			})];
	}
}
