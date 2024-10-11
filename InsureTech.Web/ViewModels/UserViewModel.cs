// InsureTech.Web/ViewModels/UserViewModel.cs

using System.ComponentModel.DataAnnotations;

namespace InsureTech.Web.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
