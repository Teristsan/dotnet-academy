namespace DotNetAcademy.Models;

public class ItemModel
{
	public int Id { get; set; }
    public byte[] Poster { get; set; }
	public string Title { get; set; }
	public DateOnly ReleaseDate { get; set; }
	public string Genre { get; set; }
	public decimal Rating { get; set; }
}
