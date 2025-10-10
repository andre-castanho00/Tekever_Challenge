using Microsoft.AspNetCore.Identity;

namespace Tekever_Challenge.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserFavorites> Favorites { get; set; } = new List<UserFavorites>();
    }
}
