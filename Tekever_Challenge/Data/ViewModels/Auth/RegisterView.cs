using System.ComponentModel.DataAnnotations;

namespace Tekever_Challenge.Data.ViewModels.Auth
{
    /// <summary>
    /// Represents the registration details provided by a user.
    /// Used when creating a new account via the AuthController.
    /// </summary>
    public class RegisterView
    {
        /// <summary>
        /// The username chosen by the user.
        /// </summary>
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        /// <summary>
        /// The email address of the user.
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        /// <summary>
        /// The password chosen by the user.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
