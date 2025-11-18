using DotNetAcademy.Enums;
using DotNetAcademy.Models;
using DotNetAcademy.Models.Mappings;
using DotNetAcademy.Services.ItemService;
using Microsoft.AspNetCore.Components;

namespace DotNetAcademy.Components.ItemComponents;

public partial class ItemCompList
{
	[Inject]
	private IItemService ItemService { get; set; } = null!;
	[Inject]
	private NavigationManager NavigationManager { get; set; } = null!;

	[Parameter]
	public MediaTypeEnum MediaType { get; set; } = MediaTypeEnum.Movie;
	
	private List<ItemModel> Items { get; set; } = new();
	private int TotalPages { get; set; }
	private int CurrentPage { get; set; } = 1;
	private int ItemsPerPage { get; set; } = 8;

	private bool isItemAdditionSuccessful = false;
	private bool isItemDeletionSuccessful = false;

	protected override async Task OnInitializedAsync()
	{
		var uri = new Uri(NavigationManager.Uri);
		var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
		isItemAdditionSuccessful = query["success"] == "1";
		isItemDeletionSuccessful = query["success_delete"] == "1";

		await LoadPageItemList(MediaType);

		if (isItemAdditionSuccessful || isItemDeletionSuccessful)
		{
			_ = Task.Run(async () =>
			{
				await Task.Delay(4000);
				isItemAdditionSuccessful = false;
				isItemDeletionSuccessful = false;
				await InvokeAsync(StateHasChanged);
			});
		}
	}

	private async Task LoadPageItemList(MediaTypeEnum mediaType)
	{
		var mediaTypeString = mediaType.ToString("G");
		var totalItems = await ItemService.GetPaginatedItemsAsync(CurrentPage, ItemsPerPage, mediaTypeString);
		var totalItemsCount = await ItemService.CountItemsAsync(mediaTypeString);

		TotalPages = (int)Math.Ceiling((double)totalItemsCount / ItemsPerPage);
		Items = totalItems?.ToModelList() ?? new List<ItemModel>();
	}

	private async Task GetPageItems(int page)
	{
		if (page >= 1 && page <= TotalPages)
		{
			CurrentPage = page;
			await LoadPageItemList(MediaType);
		}
	}

	private async Task ChangeMediaType(MediaTypeEnum mediaType)
	{
		MediaType = mediaType;
		CurrentPage = 1;
		await LoadPageItemList(MediaType);
	}

	private void NavigateToItemDetail(int itemId)
	{
		NavigationManager.NavigateTo($"/item/{itemId}");
	}
}
