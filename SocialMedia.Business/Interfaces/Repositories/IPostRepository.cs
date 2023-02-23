using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<bool> InsertAsync(Post post, List<int> tagIds);
        Task<bool> ExistsAsync(int id);
        Task<List<Post>> GetAllPostsFromUserAsync(int userId);
    }
}
