using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postServices)
        {
            _postService = postServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}
