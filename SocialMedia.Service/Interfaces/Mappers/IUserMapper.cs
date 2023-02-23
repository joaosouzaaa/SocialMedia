using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.User;

namespace SocialMedia.Service.Interfaces.Mappers
{
    public interface IUserMapper
    {
        User SaveRequestToDomain(UserSaveRequest userSaveRequest);
    }
}
