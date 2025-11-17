namespace DotNetAcademy.Services.Dto;

public record ItemInfo(int Id, byte[] Poster, string Title, DateOnly ReleaseDate, string Genre, decimal Rating);
