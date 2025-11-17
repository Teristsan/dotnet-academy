using DotNetAcademy.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace DotNetAcademy.Models;

public class ItemFormModel
{
	[Required(ErrorMessage = "Media type is required.")]
	public string? MediaType { get; set; }
	[Required(ErrorMessage = "Title is required.")]
	public string? Title { get; set; }
	[Required(ErrorMessage = "Description is required.")]
	[MaxLength(255)]
	public string? Description { get; set; }
	[Required(ErrorMessage = "Poster image is required.")]
	[MinLength(1, ErrorMessage = "Poster image is required.")]
	public required byte[] Poster { get; set; }
	[Required(ErrorMessage = "Release date is required.")]
	[Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10.")]
	public decimal Rating { get; set; }
	[Required(ErrorMessage = "1-5 images are required.")]
	[MinLength(1, ErrorMessage = "1-5 images are required.")]
	public List<byte[]> Images { get; set; } = [];
	[Required(ErrorMessage = "Release date is required.")]
	public DateOnly ReleaseDate { get; set; }
	[Required(ErrorMessage = "Genre is required.")]
	public string? Genre { get; set; }
}
