using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.Post;

namespace SocialMedia.Service.Interfaces.Mappers
{
    public interface IPostMapper
    {
        public Post SaveRequestToDomain(PostSaveRequest postSaveRequest);
    }
}
