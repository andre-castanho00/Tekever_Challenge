using System.ComponentModel.DataAnnotations;

namespace Tekever_Challenge.Data.ViewModels.Auth
{
    public class LoginView
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
