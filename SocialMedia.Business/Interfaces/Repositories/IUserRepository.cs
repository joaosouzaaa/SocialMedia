using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> InsertAsync(User user);
    }
}
