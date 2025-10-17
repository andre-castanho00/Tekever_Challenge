using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using System.Security.Claims;
using Tekever_Challenge.Data;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Controllers
{
    [Route("api/users")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves information about the currently authenticated user.
        /// </summary>
        /// <returns>
        /// 200 OK with the user's ID, username, and email,
        /// 401 Unauthorized if the user is not authenticated.
        /// </returns>
        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var username = User.Identity.Name;

            return Ok(new { userId, username, email });
        }

        /// <summary>
        /// Retrieves the list of TV shows marked as favorites by the authenticated user.
        /// </summary>
        /// <returns>
        /// 200 OK with a list of favorite TV shows including their genres,
        /// 401 Unauthorized if the user is not authenticated.
        /// </returns>
        [HttpGet("favorites")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>
        /// Adds a TV show to the authenticated user's favorites list.
        /// </summary>
        /// <param name="tvshowid">The ID of the TV show to add.</param>
        /// <returns>
        /// 200 OK if added successfully,
        /// 400 Bad Request if the show is already a favorite,
        /// 401 Unauthorized if the user is not authenticated.
        /// </returns>
        [HttpPost("favorites/add/{tvshowid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>
        /// Removes a TV show from the authenticated user's favorites list.
        /// </summary>
        /// <param name="tvshowid">The ID of the TV show to remove.</param>
        /// <returns>
        /// 200 OK if removed successfully,
        /// 404 Not Found if the favorite does not exist,
        /// 401 Unauthorized if the user is not authenticated.
        /// </returns>
        [HttpDelete("favorites/remove/{tvshowid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>
        /// Recommends TV shows to the authenticated user based on the genres of their favorite shows.
        /// </summary>
        /// <returns>
        /// 200 OK with a list of recommended shows including genres,
        /// 401 Unauthorized if the user is not authenticated.
        /// </returns>
        [HttpGet("recommendations")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetRecommendedShowsByFavoriteGenres()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Invalid or missing user ID in token." });

            var favoriteGenreIds = _context.UserFavorites
                .Where(f => f.UserId == userId)
                .Include(f => f.TvShow)
                    .ThenInclude(t => t.TvShowGenres)
                .SelectMany(f => f.TvShow.TvShowGenres.Select(tg => tg.GenreId))
                .Distinct()
                .ToList();

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
