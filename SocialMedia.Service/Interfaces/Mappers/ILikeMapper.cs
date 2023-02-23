using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.Like;

namespace SocialMedia.Service.Interfaces.Mappers
{
    public interface ILikeMapper
    {
        Like SaveRequestToDomain(LikeSaveRequest likeSaveRequest);
    }
}
