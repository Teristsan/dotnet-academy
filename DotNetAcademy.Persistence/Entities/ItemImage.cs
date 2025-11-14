namespace DotNetAcademy.Persistence.Entities;

public class ItemImage
{
	public int Id { get; set; }
	public int ItemId { get; set; }
	public Item Item { get; set; } = null!;
	public required byte[] Data { get; set; }
}
