namespace DotNetAcademy.Services.Dto;

public record ListItemDetails(
    int Id,
    string MediaType,
    string Title,
    byte[] Poster,
    string Description,
    decimal Rating,
    List<byte[]> Images,
    DateOnly ReleaseDate,
    string Genre
);
