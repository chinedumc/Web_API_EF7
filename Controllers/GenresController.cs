using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI_EF.DTOs;
using webAPI_EF.Entities;

namespace webAPI_EF.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Get()
        {
            return await context.Genres.ToListAsync();
        }

        [HttpPost]
        //public async Task<ActionResult> Post(Genre genre)
        public async Task<ActionResult> Post(GenreCreationDTO genreCreationDTO)
        {
            var genreExistsWithThatName = await context.Genres.AnyAsync(g => g.Name == genreCreationDTO.Name);

            if (genreExistsWithThatName)
            {
                return BadRequest("There's already a genre with the name: " + genreCreationDTO.Name);
            }

            var genre = mapper.Map<Genre>(genreCreationDTO);
            context.Add(genre);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("several")]
        public async Task<ActionResult> Post(GenreCreationDTO[] genreCreationDTO)
        {
            var genres = mapper.Map<Genre[]>(genreCreationDTO);
            context.AddRange(genres);
            await context.SaveChangesAsync();
            return Ok();
        }

        //The connected Model of Updating Data in EF
        [HttpPut("{id:int}/name2")]
        public async Task<ActionResult> Put(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.Name = genre.Name + "2";
            await context.SaveChangesAsync();
            return Ok();
        }

        //The Disconnected method, using DTO
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            context.Update(genre);
            await context.SaveChangesAsync();
            return Ok();


        }

        [HttpDelete("{id:int}/modern")]
        public async Task<ActionResult> Delete(int id)
        {
            var removedRows = await context.Genres.Where(g => g.Id ==id).ExecuteDeleteAsync();

            if (removedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}/oldway")]
        public async Task<ActionResult> DeleteOldWay(int id)
        {
var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id ==id);   

            if(genre is null)
            {
                return NotFound();
            }

            context.Remove(genre);
            await context.SaveChangesAsync();
            return NoContent() ;
        }

    }


}
