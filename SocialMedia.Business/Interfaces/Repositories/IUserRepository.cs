using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> InsertAsync(User user);
        Task<bool> ExistsAsync(int id);
        Task<bool> UserNameExistsAsync(string userName);
        Task<bool> EmailExistsAsync(string email);
    }
}
