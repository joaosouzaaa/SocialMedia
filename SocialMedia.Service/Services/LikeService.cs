using FluentValidation;
using SocialMedia.Business.Enums;
using SocialMedia.Business.Extensions;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Business.Interfaces.Settings.NotificationSettings;
using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.Like;
using SocialMedia.Service.Interfaces.Mappers;
using SocialMedia.Service.Interfaces.Services;
using SocialMedia.Service.Services.BaseServices;

namespace SocialMedia.Service.Services
{
    public sealed class LikeService : BaseService<Like>, ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly ILikeMapper _likeMapper;
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public LikeService(ILikeRepository likeRepository, ILikeMapper likeMapper, 
                           IPostService postService, IUserService userService,
                           IValidator<Like> validator, INotificationHandler notificationHandler) 
                           : base(validator, notificationHandler)
        {
            _likeRepository = likeRepository;
            _likeMapper = likeMapper;
            _postService = postService;
            _userService = userService;
        }

        public async Task<bool> InsertAsync(LikeSaveRequest likeSaveRequest)
        {
            var like = _likeMapper.SaveRequestToDomain(likeSaveRequest);

            if (!await ValidateAsync(like))
                return false;

            if (!await _userService.ExistsAsync(like.UserId))
                return _notificationHandler.AddNotification(EMessage.NotFound.ToString(), EMessage.NotFound.Description().FormatTo("User"));

            if(!await _postService.ExistsAsync(like.PostId))
                return _notificationHandler.AddNotification(EMessage.NotFound.ToString(), EMessage.NotFound.Description().FormatTo("Post"));

            if (await _likeRepository.LikeExistsByRelationshipsAsync(like.UserId, like.PostId))
                return _notificationHandler.AddNotification("Like", "Post already has a like.");

            return await _likeRepository.InsertAsync(like);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _likeRepository.LikeExistsAsync(id))
                return _notificationHandler.AddNotification(EMessage.NotFound.ToString(), EMessage.NotFound.Description().FormatTo("Like"));

            return await _likeRepository.DeleteAsync(id);
        }
    }
}
