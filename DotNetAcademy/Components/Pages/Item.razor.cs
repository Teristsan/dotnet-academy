using DotNetAcademy.Models;
using DotNetAcademy.Models.Mappings;
using DotNetAcademy.Services.ItemService;
using Microsoft.AspNetCore.Components;

namespace DotNetAcademy.Components.Pages;

public partial class Item
{
    [Inject] private IItemService ItemService { get; set; } = default!;

    [SupplyParameterFromForm]
    public ItemModel ItemModel { get; set; } = new();

    public List<ItemModel>? Items { get; set; }
    [Parameter] public int DefaultPageSize { get; set; } = 10;

    private int PageSize { get; set; }
    private int CurrentPage { get; set; } = 1;
    private readonly int[] PageSizes = [5, 10, 20, 50];
    private int TotalPages { get; set; } = 1;
    private int TotalItems { get; set; }
    private bool _isLoading;

    protected override async Task OnInitializedAsync()
    {
        PageSize = DefaultPageSize;
        await LoadPageAsync();
    }

    private async Task LoadPageAsync()
    {
        if (_isLoading) return;
        _isLoading = true;
        try
        {
            var pageInfo = await ItemService.GetPaginatedItemsAsync(CurrentPage, PageSize);

            TotalItems = pageInfo.TotalItems;
            TotalPages = Math.Max(1, (int)Math.Ceiling(TotalItems / (double)PageSize));

            // If current page is now out of range (e.g. after deletes or page size change), normalize and refetch.
            if (CurrentPage > TotalPages)
            {
                CurrentPage = TotalPages;
                pageInfo = await ItemService.GetPaginatedItemsAsync(CurrentPage, PageSize);
            }

            Items = pageInfo.Items.ToModelList();
            StateHasChanged();
        }
        finally
        {
            _isLoading = false;
        }
    }

    private async Task OnPageSizeChanged(ChangeEventArgs e)
    {
        if (int.TryParse(e?.Value?.ToString(), out var newSize) && newSize > 0 && newSize != PageSize)
        {
            PageSize = newSize;
            CurrentPage = 1;
            await LoadPageAsync();
        }
    }

	private async Task NextPage()
	{
		if (CurrentPage < TotalPages)
		{
			CurrentPage++;
			await LoadPageAsync();
		}
	}

	private async Task PreviousPage()
	{
		if (CurrentPage > 1)
		{
			CurrentPage--;
			await LoadPageAsync();
		}
	}

	private async Task AddItem()
    {
        await ItemService.AddItemAsync(ItemModel.Name!, ItemModel.Description!);
        await LoadPageAsync();
        ItemModel = new();
    }

    private async Task DeleteItem(int itemId)
    {
        await ItemService.DeleteItemAsync(itemId);
        await LoadPageAsync();
    }

    private bool IsPreviousDisabled => CurrentPage == 1;
    private bool IsNextDisabled => CurrentPage == TotalPages;
}