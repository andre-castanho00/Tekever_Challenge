using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tekever_Challenge.Data;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TvShowsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("shows")]
        public async Task<IActionResult> GetAllTvShows()
        {
            var shows = await _context.TvShows
                .Include(show => show.Seasons)
                    // .ThenInclude(season => season.Episodes)
                .Include(show => show.TvShowGenres)
                .Include(show => show.TvShowActors)
                .ToListAsync();

            return Ok(shows);
        }

        [HttpGet("showsByGenre")]
        public async Task<IActionResult> GetShowsByGenre(int genreId)
        {
            var shows = await _context.TvShows
                .Where(show => show.TvShowGenres.Any(tg => tg.GenreId == genreId))
                .Include(show => show.TvShowGenres)
                    .ThenInclude(tg => tg.GenreId)
                .Include(show => show.TvShowActors)
                    .ThenInclude(ta => ta.ActorId)
                .Include(show => show.Seasons)
                    .ThenInclude(season => season.Episodes)
                .ToListAsync();

            if (!shows.Any())
                return NotFound($"No TV shows found for Genre ID {genreId}");

            return Ok(shows);
        }

        [HttpGet("episodes")]
        public async Task<IActionResult> GetShowEpisodes(int showId)
        {
            var episodes = await _context.SeasonEpisodes
                .Where(e => e.Season.TvShowId == showId).ToListAsync();

            return Ok(episodes);
        }

        [HttpGet("details")]
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

        [HttpGet("seasons")]
        public async Task<IActionResult> GetShowSeasons(int showId)
        {
            var seasons = await _context.Seasons
                .Include(s => s.Episodes)
                .Where(s => s.TvShowId == showId).ToListAsync();

            return Ok(seasons);
        }

        [HttpGet("genres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _context.Genres.ToListAsync();

            return Ok(genres);
        }
    }
}
