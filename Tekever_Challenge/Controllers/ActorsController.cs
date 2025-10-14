using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tekever_Challenge.Data;

namespace Tekever_Challenge.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ActorsController(DatabaseContext context) { 
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _context.Actors.ToListAsync();

            return Ok(actors);
        }

        //[HttpGet("details")]
        //public async Task<IActionResult> GetActorDetails(int actorId)
        //{
        //    var actors = await _context.Actors
        //        .Where(act => act.Id == actorId)
        //        .Include(act => act.TvShowActors)
        //            .ThenInclude(aux => aux.TvShow)
        //        .ToListAsync();

        //    return Ok(actors);
        //}

        [HttpGet("details")]
        public async Task<IActionResult> GetActorDetails([FromBody]int actorId)
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
