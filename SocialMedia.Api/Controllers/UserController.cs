using Microsoft.AspNetCore.Mvc;
using SocialMedia.Service.DataTransferObjects.Requests.User;
using SocialMedia.Service.Interfaces.Services;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("insert")]
        public async Task<bool> InsertAsync([FromBody] UserSaveRequest userSaveRequest) =>
            await _userService.InsertAsync(userSaveRequest);
    }
}
