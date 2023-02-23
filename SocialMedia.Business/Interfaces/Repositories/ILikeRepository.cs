using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Interfaces.Repositories
{
    public interface ILikeRepository
    {
        Task<bool> InsertAsync(Like like);
        Task<bool> LikeExistsByRelationshipsAsync(int userId, int postId);
        Task<bool> LikeExistsAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
