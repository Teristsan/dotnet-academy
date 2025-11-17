using DotNetAcademy.Persistence.Constants;
using System.ComponentModel.DataAnnotations;

namespace DotNetAcademy.Models;

public class ProfileFormModel
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 20 characters")]
    public string FirstName { get; set; } = "";
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters")]
    public string LastName { get; set; } = "";
    
    [Required(ErrorMessage = "Username is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
    public string UserName { get; set; } = "";
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = "";
    
    [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
    public string Description { get; set; } = "";
    
    public byte[]? ProfileImage { get; set; }
}
