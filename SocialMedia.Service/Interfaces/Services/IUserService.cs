using SocialMedia.Service.DataTransferObjects.Requests.User;

namespace SocialMedia.Service.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> InsertAsync(UserSaveRequest userSaveRequest);
        Task<bool> ExistsAsync(int id);
    }
}
