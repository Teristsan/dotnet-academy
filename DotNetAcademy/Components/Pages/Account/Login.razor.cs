using DotNetAcademy.Models;
using Microsoft.AspNetCore.Components;

Using Microsoft.AspNetCore.Components.Forms;

namespace DotNetAcademy.Components.Pages.Account;
{
    public partial class Login
    {
        [Inject] private SignInManager<ApplicationUser> SignInManager { get; set; } = default!;
        
        [SupplyParameterFromForm]
        private LoginModel Input { get; set; } = new();

        private async Task HandleLogin(EditContext args)
        {
          var result= await SignInManager.PasswordSignInAsync
          (Input.Email,Input.Password,Input.RememberMe, lockoutFailure: false);
        }
    }
}