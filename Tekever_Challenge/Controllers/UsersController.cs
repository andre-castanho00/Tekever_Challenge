using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tekever_Challenge.Data;

namespace Tekever_Challenge.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public UsersController(DatabaseContext context) { 
            _context = context;
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var username = User.Identity.Name;

            return Ok(new { userId, username, email });
        }

        [HttpGet("favorites")]
        [Authorize]
        public IActionResult GetUserFavorites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "Invalid or missing user ID in token." });
            }

            var favorites = _context.UserFavorites
                .Where(f => f.UserId == userId)
                .Include(f => f.TvShow)
                .Select(f => new
                {
                    f.TvShow.Id,
                    f.TvShow.Title,
                    f.TvShow.Rating,
                    f.TvShow.ReleaseDate
                })
                .ToList();

            return Ok(favorites);
        }

    }
}
