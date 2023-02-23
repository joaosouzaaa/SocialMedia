using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.Like;
using SocialMedia.Service.Interfaces.Mappers;

namespace SocialMedia.Service.Mappers
{
    public sealed class LikeMapper : ILikeMapper
    {
        public Like SaveRequestToDomain(LikeSaveRequest likeSaveRequest) =>
            new Like()
            {
                PostId = likeSaveRequest.PostId,
                UserId = likeSaveRequest.UserId
            };
    }
}
