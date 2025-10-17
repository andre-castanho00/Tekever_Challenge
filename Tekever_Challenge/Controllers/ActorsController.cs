using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using Tekever_Challenge.Data;

namespace Tekever_Challenge.Controllers
{
    [Route("api/actors")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ActorsController(DatabaseContext context) { 
            _context = context;
        }

        /// <summary>
        /// Retrieves all actors from the database.
        /// </summary>
        /// <returns>
        /// 200 OK with a list of all actors.
        /// </returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _context.Actors.ToListAsync();

            return Ok(actors);
        }

        /// <summary>
        /// Retrieves detailed information about a specific actor,
        /// including the TV shows they are associated with.
        /// </summary>
        /// <param name="actorId">The ID of the actor to retrieve details for.</param>
        /// <returns>
        /// 200 OK with the actor details and related TV shows if found,
        /// 404 Not Found if no actor exists with the specified ID.
        /// </returns>
        [HttpGet("details/{actorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetActorDetails(int actorId)
        {
            var details = await _context.Actors
                .Where(a => a.Id == actorId)
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    TvShows = a.TvShowActors
                                .Select(ta => new
                                {
                                    ta.TvShow.Id,
                                    ta.TvShow.Title,
                                    ta.TvShow.Description,
                                    ta.TvShow.ReleaseDate,
                                    ta.TvShow.Rating
                                })
                                .ToList()
                })
                .FirstOrDefaultAsync();

            if (details == null)
                return NotFound($"Actor with ID {actorId} not found");

            return Ok(details);
        }
    }
}
