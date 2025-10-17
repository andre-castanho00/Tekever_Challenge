using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using Tekever_Challenge.Data;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TvShowsController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all TV shows including their seasons, genres, and actors.
        /// </summary>
        /// <returns>200 OK with a list of all TV shows.</returns>
        [HttpGet("shows")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTvShows()
        {
            var shows = await _context.TvShows
                .Include(show => show.Seasons)
                .Include(show => show.TvShowGenres)
                .Include(show => show.TvShowActors)
                .ToListAsync();

            return Ok(shows);
        }

        /// <summary>
        /// Retrieves all TV shows associated with a specific genre.
        /// </summary>
        /// <param name="genreId">The ID of the genre.</param>
        /// <returns>
        /// 200 OK with the list of TV shows in that genre,
        /// 404 Not Found if no shows exist for the specified genre.
        /// </returns>
        [HttpGet("showsByGenre/{genreId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShowsByGenre(int genreId)
        {
            var shows = await _context.TvShows
                .Where(show => show.TvShowGenres.Any(tg => tg.GenreId == genreId))
                .Include(show => show.Seasons)
                .Include(show => show.TvShowGenres)
                .Include(show => show.TvShowActors)
                .ToListAsync();

            if (!shows.Any())
                return NotFound($"No TV shows found for Genre ID {genreId}");

            return Ok(shows);
        }

        /// <summary>
        /// Retrieves all episodes of a specific TV show.
        /// </summary>
        /// <param name="showId">The ID of the TV show.</param>
        /// <returns>200 OK with a list of episodes.</returns>
        [HttpGet("episodes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetShowEpisodes(int showId)
        {
            var episodes = await _context.SeasonEpisodes
                .Where(e => e.Season.TvShowId == showId).ToListAsync();

            return Ok(episodes);
        }

        /// <summary>
        /// Retrieves detailed information about a specific TV show,
        /// including seasons, genres, and actors.
        /// </summary>
        /// <param name="showId">The ID of the TV show.</param>
        /// <returns>
        /// 200 OK with the TV show details,
        /// 404 Not Found if the show does not exist.
        /// </returns>
        [HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShowDetails(int showId)
        {
            var details = await _context.TvShows
                .Where(show => show.Id == showId)
                .Include(show => show.Seasons)
                .Include(show => show.TvShowGenres)
                    .ThenInclude(tg => tg.Genre)          // include Genre object for each TvShowGenre
                .Include(show => show.TvShowActors)
                    .ThenInclude(ta => ta.Actor)          // include Actor object for each TvShowActor
                .FirstOrDefaultAsync();                    // single show instead of a list

            if (details == null)
                return NotFound($"No TV show found with ID {showId}");

            return Ok(details);
        }

        /// <summary>
        /// Retrieves detailed information about a specific TV show by its name.
        /// </summary>
        /// <param name="name">The title of the TV show.</param>
        /// <returns>
        /// 200 OK with the TV show details,
        /// 400 Bad Request if the name is empty,
        /// 404 Not Found if no show matches the name.
        /// </returns>
        [HttpGet("detailsByName/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShowDetailsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Show name must be provided.");

            var formattedName = name.Replace("+", " ").Trim();

            var show = await _context.TvShows
                .Where(show => show.Title.ToLower() == formattedName.ToLower())
                .Include(show => show.Seasons)
                    .ThenInclude(season => season.Episodes)
                .Include(show => show.TvShowGenres)
                    .ThenInclude(tg => tg.Genre)
                .Include(show => show.TvShowActors)
                    .ThenInclude(ta => ta.Actor)
                .FirstOrDefaultAsync();

            if (show == null)
                return NotFound($"No TV show found with the name '{formattedName}'.");

            return Ok(show);
        }

        /// <summary>
        /// Retrieves all seasons for a specific TV show, including episodes.
        /// </summary>
        /// <param name="showId">The ID of the TV show.</param>
        /// <returns>200 OK with a list of seasons.</returns>
        [HttpGet("seasons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetShowSeasons(int showId)
        {
            var seasons = await _context.Seasons
                .Include(s => s.Episodes)
                .Where(s => s.TvShowId == showId).ToListAsync();

            return Ok(seasons);
        }

        /// <summary>
        /// Retrieves all available genres.
        /// </summary>
        /// <returns>200 OK with a list of genres.</returns>
        [HttpGet("genres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _context.Genres.ToListAsync();

            return Ok(genres);
        }
    }
}
