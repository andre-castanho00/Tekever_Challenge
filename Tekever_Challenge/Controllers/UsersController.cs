using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tekever_Challenge.Data;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public UsersController(DatabaseContext context)
        {
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
                    .ThenInclude(t => t.TvShowGenres)
                        .ThenInclude(tg => tg.Genre)
                .Select(f => new
                {
                    f.TvShow.Id,
                    f.TvShow.Title,
                    f.TvShow.Rating,
                    f.TvShow.ReleaseDate,
                    Genres = f.TvShow.TvShowGenres
                        .Select(tg => new
                        {
                            tg.Genre.Id,
                            tg.Genre.Name
                        })
                })
                .ToList();

            return Ok(favorites);
        }

        [HttpPost("favorites/add/{tvshowid}")]
        [Authorize]
        public IActionResult AddToFavorites([FromRoute] int tvshowid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Invalid or missing user ID in token." });

            var existingFavorite = _context.UserFavorites
                .FirstOrDefault(f => f.UserId == userId && f.TvShowId == tvshowid);

            if (existingFavorite != null)
                return BadRequest(new { message = "Show already in favorites." });

            var favorite = new UserFavorites
            {
                UserId = userId,
                TvShowId = tvshowid
            };

            _context.UserFavorites.Add(favorite);
            _context.SaveChanges();

            return Ok(new { message = "Added to favorites successfully." });
        }

        [HttpDelete("favorites/remove/{tvshowid}")]
        [Authorize]
        public IActionResult RemoveFromFavorites(int tvshowid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Invalid or missing user ID in token." });

            var favorite = _context.UserFavorites
                .FirstOrDefault(f => f.UserId == userId && f.TvShowId == tvshowid);

            if (favorite == null)
                return NotFound(new { message = "Favorite not found." });

            _context.UserFavorites.Remove(favorite);
            _context.SaveChanges();

            return Ok(new { message = "Removed from favorites successfully." });
        }

        [HttpGet("recommendations")]
        [Authorize]
        public IActionResult GetRecommendedShowsByFavoriteGenres()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Invalid or missing user ID in token." });

            // Get user's favorite genres
            var favoriteGenreIds = _context.UserFavorites
                .Where(f => f.UserId == userId)
                .Include(f => f.TvShow)
                    .ThenInclude(t => t.TvShowGenres)
                .SelectMany(f => f.TvShow.TvShowGenres.Select(tg => tg.GenreId))
                .Distinct()
                .ToList();

            // Now get all shows that have *any* of those genres
            var recommendedShows = _context.TvShows
                .Include(t => t.TvShowGenres)
                    .ThenInclude(tg => tg.Genre)
                .Where(t => t.TvShowGenres.Any(tg => favoriteGenreIds.Contains(tg.GenreId)))
                .Select(t => new
                {
                    t.Id,
                    t.Title,
                    t.Rating,
                    t.ReleaseDate,
                    Genres = t.TvShowGenres.Select(tg => new
                    {
                        tg.Genre.Id,
                        tg.Genre.Name
                    })
                })
                .ToList();

            return Ok(recommendedShows);
        }

    }
}
