using Application.Posts.Commands.CreatePost;
using Application.Posts.Queries.GetAllPosts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllPostsDto>>> GetAllPosts()
        {
            var response = await Mediator.Send(new GetAllPostsQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePostDto>> CreatePost(CreatePostCommand command)
        {
            var response = await Mediator.Send(command);
            return CreatedAtAction(nameof(CreatePost), response);
        }
    }
}