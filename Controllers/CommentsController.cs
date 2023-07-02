using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webAPI_EF.DTOs;
using webAPI_EF.Entities;

namespace webAPI_EF.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId:int}/comments")]
    public class CommentsController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CommentsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int movieId, CommentCreationDTO commentCreationDTO)
        {
            var comment = mapper.Map<Comment>(commentCreationDTO);
            comment.MovieId = movieId;
            context.Add(comment);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
