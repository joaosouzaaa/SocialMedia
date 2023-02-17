using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Interfaces.Repositories
{
    public interface ITagRepository
    {
        Task<int?> InsertAsync(Tag tag);
        Task<int?> GetTagIdByNameAsync(string name);
    }
}
