namespace DotNetAcademy.Persistence.Entities;

public class Item
{
	public int Id { get; set; }
	public required string MediaType { get; set; }
	public required string Title { get; set; }
	public required byte[] Poster { get; set; }
	public required string Description { get; set; }
	public decimal Rating { get; set; }
	public List<ItemImage> Images { get; set; } = [];
	public DateOnly ReleaseDate { get; set; }
	public required string Genre { get; set; }
}