using Microsoft.AspNetCore.Identity;

namespace DotNetAcademy.Persistence.Entities;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Description { get; set; }
}
