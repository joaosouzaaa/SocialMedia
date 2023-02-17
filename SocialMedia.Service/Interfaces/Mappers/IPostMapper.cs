using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests;

namespace SocialMedia.Service.Interfaces.Mappers
{
    public interface IPostMapper
    {
        public Post SaveRequestToDomain(PostSaveRequest postSaveRequest);
    }
}
