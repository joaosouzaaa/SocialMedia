using FluentValidation;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Business.Interfaces.Settings.NotificationSettings;
using SocialMedia.Domain.Entities;
using SocialMedia.Service.Interfaces.Services;
using SocialMedia.Service.Services.BaseServices;

namespace SocialMedia.Service.Services
{
    public sealed class TagService : BaseService<Tag>, ITagService
    {
        private readonly ITagRepository _tagRepository;
        
        public TagService(ITagRepository tagRepository, IValidator<Tag> validator, INotificationHandler notificationHandler) 
                          : base(validator, notificationHandler)
        {
            _tagRepository = tagRepository;
        }

        public async Task<int?> InsertDomainTagAsync(Tag tag)
        {
            if (!await ValidateAsync(tag))
                return null;

            return await _tagRepository.InsertAsync(tag);
        }

        public async Task<int?> GetTagIdByNameAsync(string name) =>
            await _tagRepository.GetTagIdByNameAsync(name);
    }
}
