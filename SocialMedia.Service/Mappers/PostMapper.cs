using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.Post;
using SocialMedia.Service.Interfaces.Mappers;

namespace SocialMedia.Service.Mappers
{
    public sealed class PostMapper : IPostMapper
    {
        public Post SaveRequestToDomain(PostSaveRequest postSaveRequest) =>
            new Post()
            {
                Text = postSaveRequest.Text,
                UserId = postSaveRequest.UserId
            };
    }
}
