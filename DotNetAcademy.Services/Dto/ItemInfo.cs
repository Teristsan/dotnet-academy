namespace DotNetAcademy.Services.Dto;

public record ItemInfo(byte[] Poster, string Title, DateOnly ReleaseDate, string Genre, decimal Rating);