using Microsoft.AspNetCore.Mvc;
using SocialMedia.Service.DataTransferObjects.Requests.Post;
using SocialMedia.Service.Interfaces.Services;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("insert")]
        public async Task<bool> InsertAsync([FromBody] PostSaveRequest postSaveRequest) =>
            await _postService.InsertAsync(postSaveRequest);

        [HttpGet("get-all")]
        public async Task GetAllPostsFromUserAsync([FromQuery] int userId) =>
            await _postService.GetAllPostsFromUserAsync(userId);
    }
}
