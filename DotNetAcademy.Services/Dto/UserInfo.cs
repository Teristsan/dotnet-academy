namespace DotNetAcademy.Services.Dto;

public record UserInfo(string FirstName, string LastName, string UserName, string Email, string Description, byte[]? ProfileImage);