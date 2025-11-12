namespace DotNetAcademy.Persistence.Entities;

public class Item
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required string Description { get; set; }
}