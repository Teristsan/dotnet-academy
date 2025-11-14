using Microsoft.AspNetCore.Components;

namespace DotNetAcademy.Components.Pages;

public partial class Home
{
	[Inject]
	NavigationManager NavigationManager { get; set; } = null!;

	private bool isItemAdditionSuccessful = false;

	protected override async void OnInitialized()
	{
		var uri = new Uri(NavigationManager.Uri);
		var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
		isItemAdditionSuccessful = query["success"] == "1";

		if (isItemAdditionSuccessful)
		{
			// Wait 4 seconds, then hide the message
			await Task.Delay(4000);
			isItemAdditionSuccessful = false;
			StateHasChanged();
		}
	}
}