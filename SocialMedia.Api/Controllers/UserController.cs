using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("insert")]
        public async Task<bool> InsertAsync([FromBody] User user) =>
            await _userRepository.InsertAsync(user);
    }
}
