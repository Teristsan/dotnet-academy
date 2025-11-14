using DotNetAcademy.Models;
using DotNetAcademy.Services.Dto;
using DotNetAcademy.Services.ItemService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace DotNetAcademy.Components.Pages;

public partial class AddItem
{
	[Inject]
	private IItemService ItemService { get; set; } = null!;
	[Inject]
	private NavigationManager NavigationManager { get; set; } = null!;

	[SupplyParameterFromForm]
	private ItemModel Item { get; set; }

	protected override void OnInitialized()
	{
		Item ??= new ItemModel
		{
			MediaType = string.Empty,
			Title = string.Empty,
			Poster = Array.Empty<byte>(),
			Description = string.Empty,
			Rating = 0,
			Images = [],
			ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
			Genre = string.Empty
		};
	}

	private async Task HandlePosterUpload(InputFileChangeEventArgs e)
	{
		var file = e.File;
		using var memoryStream = new MemoryStream();
		await file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(memoryStream);
		Item!.Poster = memoryStream.ToArray();
	}

	private async Task HandleGalleryUpload(InputFileChangeEventArgs e)
	{
		const int maxFiles = 5;
		var files = e.GetMultipleFiles(maxFiles);

		Item!.Images.Clear();

		foreach (var file in files)
		{
			using var memoryStream = new MemoryStream();
			await file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(memoryStream);
			Item.Images.Add(memoryStream.ToArray());
		}
	}

	private async Task Submit()
	{
		var itemInfo = new AddItemInfo(
			MediaType: Item!.MediaType,
			Title: Item!.Title,
			Poster: Item.Poster,
			Description: Item!.Description,
			Rating: Item.Rating,
			Images: Item.Images,
			ReleaseDate: Item.ReleaseDate,
			Genre: Item!.Genre
		);

		await ItemService.AddItemAsync(itemInfo);

		NavigationManager.NavigateTo("/?success=1");
	}

	private void CancelItemAddition(MouseEventArgs args)
	{
		NavigationManager.NavigateTo("/");
	}
}
