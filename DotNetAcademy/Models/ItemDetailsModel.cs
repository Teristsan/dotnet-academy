using DotNetAcademy.Persistence.Entities;

namespace DotNetAcademy.Models;

public class ItemDetailsModel
{
    public int Id { get; set; }
    public string MediaType { get; set; }
    public string Title { get; set; }
    public byte[] Poster { get; set; }
    public string Description { get; set; }
    public decimal Rating { get; set; }
    public List<byte[]> Images { get; set; } 
    public DateOnly ReleaseDate { get; set; }
    public string Genre { get; set; }
}
