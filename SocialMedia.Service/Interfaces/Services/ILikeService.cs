using SocialMedia.Service.DataTransferObjects.Requests.Like;

namespace SocialMedia.Service.Interfaces.Services
{
    public interface ILikeService
    {
        Task<bool> InsertAsync(LikeSaveRequest likeSaveRequest);
        Task<bool> DeleteAsync(int id);
    }
}
