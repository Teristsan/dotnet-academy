namespace DotNetAcademy.Persistence.Entities;

public class ItemImage
{
    public int id { get; set; }
    
    public int ItemId { get; set; }
    
    public Item Item { get; set; } = null!; //navigational property
    
    public required byte[] ImageData { get; set; }
    
}