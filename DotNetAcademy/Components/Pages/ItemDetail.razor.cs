using DotNetAcademy.Models;
using DotNetAcademy.Services.ItemService;
using Microsoft.AspNetCore.Components;

namespace DotNetAcademy.Components.Pages;

public partial class ItemDetail
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    private IItemService ItemService { get; set; } = default!;
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

	private ItemDetailsModel? itemDetails;
    private bool isLoading = true;
    private int currentImageIndex = 0;
    private bool isDeletedSuccessfully = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var result = await ItemService.GetItemDetailsByIdAsync(Id);
            
            itemDetails = new ItemDetailsModel
            {
                Id = result.Id,
                MediaType = result.MediaType,
                Title = result.Title,
                Poster = result.Poster,
                Description = result.Description,
                Rating = result.Rating,
                Images = result.Images,
                ReleaseDate = result.ReleaseDate,
                Genre = result.Genre
            };
        }
        catch (Exception)
        {
            itemDetails = null;
        }
        finally
        {
            isLoading = false;
        }
    }

    private string GetPosterBase64()
    {
        if (itemDetails?.Poster != null)
        {
            return $"data:image/jpeg;base64,{Convert.ToBase64String(itemDetails.Poster)}";
        }
        return "/Images/No_Image_Available.jpg";
    }

    private string GetImageBase64(byte[] imageData)
    {
        if (imageData != null)
        {
            return $"data:image/jpeg;base64,{Convert.ToBase64String(imageData)}";
        }
        return "/Images/No_Image_Available.jpg";
    }

    private string GetStarRating()
    {
        if (itemDetails == null) return "";

        decimal rating = itemDetails.Rating;
        int fullStars = (int)rating;
        bool hasHalfStar = (rating - fullStars) >= 0.5m;
        int emptyStars = 10 - fullStars - (hasHalfStar ? 1 : 0);

        return new string('★', fullStars) + 
               (hasHalfStar ? "⯪" : "") + 
               new string('☆', emptyStars);
    }

	private void PreviousImage()
	{
		currentImageIndex = (currentImageIndex - 1 + itemDetails!.Images.Count) % itemDetails!.Images.Count;
	}

	private void NextImage()
    {
        currentImageIndex = (currentImageIndex + 1) % itemDetails!.Images.Count;
	}

    private async Task DeleteItem(int id)
    {
        await ItemService.DeleteItemAsync(id);

		NavigationManager.NavigateTo("/?success_delete=1");
	}
}
