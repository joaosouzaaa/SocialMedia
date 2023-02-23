using Microsoft.AspNetCore.Mvc;
using SocialMedia.Service.DataTransferObjects.Requests.Like;
using SocialMedia.Service.Interfaces.Services;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("insert")]
        public async Task<bool> InsertAsync([FromBody] LikeSaveRequest likeSaveRequest) =>
            await _likeService.InsertAsync(likeSaveRequest);

        [HttpDelete("remove")]
        public async Task<bool> DeleteAsync([FromQuery] int id) =>
            await _likeService.DeleteAsync(id);
    }
}
