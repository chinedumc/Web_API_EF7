using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI_EF.DTOs;
using webAPI_EF.Entities;

namespace webAPI_EF.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovieCreationDTO movieCreationDTO)
        {
            var movie = mapper.Map<Movie>(movieCreationDTO);

            if(movie.Genres is not null)
            {
                foreach (var genre in movie.Genres)
                {
                    context.Entry(genre).State = EntityState.Unchanged;
                }
            }

            if(movie.MoviesActors is not null)
            {
                for(int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }
            context.Add(movie);
            _ = await context.SaveChangesAsync();
            return Ok();
        }
        //Eager Loading of Many to Many relationship
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await context.Movies
                //To ensure we also get comments
                .Include(x => x.Comments)

                //To include genres
                .Include(x => x.Genres)

                .Include(x => x.MoviesActors.OrderBy(ma => ma.Order))
                    //To include the Actor name from Actor entity since MovieActor does not hold Actor names
                    .ThenInclude(x => x.Actor)

                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
            {
                return NotFound();
            }
            return movie;
        }

        //With Select Loading of Many to Many relationship
        [HttpGet("select/{id:int}")]
        public async Task<ActionResult> GetSelect(int id)
        {
            var movie = await context.Movies
                .Select(mov => new
                {
                    Id = mov.Id,
                    Title = mov.Title,
                    Genre = mov.Genres.Select(g => g.Name).ToList(),
                    Actors = mov.MoviesActors.OrderBy(ma => ma.Order).Select(ma => new
                    {
                        Id = ma.ActorId,
                        Name = ma.Actor.Name,
                        Character = ma.Character
                    }),
                    CommentsQtty = mov.Comments.Count()
                })

                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        //Deleting an item with related data
        [HttpDelete("{id:int}/modern")]
        public async Task<ActionResult> Delete(int id)
        {
            var removedRows = await context.Movies.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (removedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
