using System.ComponentModel.DataAnnotations;

namespace DotNetAcademy.Models;

public class ItemModel
{
	public int Id { get; set; }
	[Required]
	[MaxLength(100)]
	public string? Name { get; set; }
	[Required]
	[MaxLength(255)]
	public string? Description { get; set; }
}
