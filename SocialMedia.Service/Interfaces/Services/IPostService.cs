using SocialMedia.Service.DataTransferObjects.Requests.Post;

namespace SocialMedia.Service.Interfaces.Services
{
    public interface IPostService
    {
        Task<bool> InsertAsync(PostSaveRequest postSaveRequest);
        Task<bool> ExistsAsync(int id);
        Task GetAllPostsFromUserAsync(int userId);
    }
}
