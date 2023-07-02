using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI_EF.DTOs;
using webAPI_EF.Entities;

namespace webAPI_EF.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actors.ToListAsync();
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string name)
        {
            //Version 1: Exact match of name
            return await context.Actors.Where(x => x.Name == name).ToListAsync();
        }

        [HttpGet("name/v2")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get2(string name)
        {
            //Version 2: Any match of name
            return await context.Actors.Where(x => x.Name.Contains(name))
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.DateOfBirth)
                .ToListAsync();
        }

        [HttpGet("idandname")]
        public async Task<ActionResult> GetIdAndName()
        {
            var actors = await context.Actors.Select(x => new { x.Id, x.Name }).ToListAsync();
            return Ok(actors);
        }

        //idAndName using DTO
        [HttpGet("idandname/v2")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdandName()
        {
            var actors = await context.Actors.Select(x => new ActorDTO { Id = x.Id, Name = x.Name }).ToListAsync();
            return Ok(actors);
        }

        [HttpGet("dateOfBirth/range")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetDOB(DateTime start, DateTime end)
        {
            return await context.Actors.Where(x => x.DateOfBirth >= start && x.DateOfBirth <= end).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if(actor is null)
            {
                return NotFound();
            }
            return actor;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreationDTO actorCreationDTO)
        {
            var actor = mapper.Map<Actor>(actorCreationDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
