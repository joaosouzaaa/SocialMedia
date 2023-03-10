using FluentValidation;
using SocialMedia.Business.Enums;
using SocialMedia.Business.Extensions;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Business.Interfaces.Settings.NotificationSettings;
using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.Post;
using SocialMedia.Service.Interfaces.Mappers;
using SocialMedia.Service.Interfaces.Services;
using SocialMedia.Service.Services.BaseServices;

namespace SocialMedia.Service.Services
{
    public sealed class PostService : BaseService<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostMapper _postMapper;
        private readonly ITagService _tagService;
        private readonly IUserService _userService;

        public PostService(IPostRepository postRepository, IPostMapper postMapper,
                           ITagService tagService, IUserService userService,
                           IValidator<Post> validator, INotificationHandler notificationHandler) 
                           : base(validator, notificationHandler)
        {
            _postRepository = postRepository;
            _postMapper = postMapper;
            _tagService = tagService;
            _userService = userService;
        }

        public async Task<bool> InsertAsync(PostSaveRequest postSaveRequest)
        {
            var post = _postMapper.SaveRequestToDomain(postSaveRequest);

            if (!await ValidateAsync(post))
                return false;

            if(!await _userService.ExistsAsync(post.UserId))
                return _notificationHandler.AddNotification(EMessage.NotFound.ToString(), EMessage.NotFound.Description().FormatTo("User"));

            var tagIds = await GetTagIdsAsync(post.Text);

            if (tagIds is null)
                return false;

            return await _postRepository.InsertAsync(post, tagIds);
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _postRepository.ExistsAsync(id);

        public async Task GetAllPostsFromUserAsync(int userId)
        {
            var postsList = await _postRepository.GetAllPostsFromUserAsync(userId);

        }

        private async Task<List<int>?> GetTagIdsAsync(string text)
        {
            var hashTags = text.ScrapHashtags();

            var tagIds = new List<int>();

            foreach (var hashTag in hashTags)
            {
                var tagId = await _tagService.GetTagIdByNameAsync(hashTag);

                if (tagId is null)
                {
                    var tag = new Tag()
                    {
                        Name = hashTag
                    };

                    var tagIdResult = await _tagService.InsertDomainTagAsync(tag);

                    if (tagIdResult is null)
                        return null;

                    tagIds.Add((int)tagIdResult);
                }
                else
                    tagIds.Add((int)tagId);
            }

            return tagIds;
        }
    }
}
