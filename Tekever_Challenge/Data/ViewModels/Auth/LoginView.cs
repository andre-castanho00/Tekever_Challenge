using System.ComponentModel.DataAnnotations;

namespace Tekever_Challenge.Data.ViewModels.Auth
{
    /// <summary>
    /// Represents the login credentials provided by a user.
    /// Used when authenticating via the AuthController.
    /// </summary>
    public class LoginView
    {
        /// <summary>
        /// The email address of the user attempting to log in.
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        /// <summary>
        /// The password of the user attempting to log in.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
