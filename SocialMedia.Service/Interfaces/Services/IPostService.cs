using SocialMedia.Service.DataTransferObjects.Requests;

namespace SocialMedia.Service.Interfaces.Services
{
    public interface IPostService
    {
        Task<bool> InsertAsync(PostSaveRequest postSaveRequest);
    }
}
