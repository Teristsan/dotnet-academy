using DotNetAcademy.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetAcademy.Components.ItemComponents;

public partial class ItemComp
{
	[Parameter]
	public GetItemModel Item { get; set; } = new()
	{
		Title = string.Empty,
		Poster = Array.Empty<byte>(),
		Rating = 0,
		ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
		Genre = string.Empty
	};

	private string GetPosterDataUrl()
	{
		if (Item.Poster == null || Item.Poster.Length == 0)
		{
			return "data:image/png;base64,"; // Or use a placeholder image URL
		}

		var base64 = Convert.ToBase64String(Item.Poster);
		return $"data:image/png;base64,{base64}";
	}
}
