using SocialMedia.Domain.Entities;

namespace SocialMedia.Service.Interfaces.Services
{
    public interface ITagService
    {
        Task<int?> InsertDomainTagAsync(Tag tag);
        Task<int?> GetTagIdByNameAsync(string name);
    }
}
