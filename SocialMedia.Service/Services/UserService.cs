using FluentValidation;
using SocialMedia.Business.Enums;
using SocialMedia.Business.Extensions;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Business.Interfaces.Settings.NotificationSettings;
using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.User;
using SocialMedia.Service.Interfaces.Mappers;
using SocialMedia.Service.Interfaces.Services;
using SocialMedia.Service.Services.BaseServices;

namespace SocialMedia.Service.Services
{
    public sealed class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserService(IUserRepository userRepository, IUserMapper userMapper,
                           IValidator<User> validator, INotificationHandler notificationHandler) 
                           : base(validator, notificationHandler)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public async Task<bool> InsertAsync(UserSaveRequest userSaveRequest)
        {
            var user = _userMapper.SaveRequestToDomain(userSaveRequest);

            if (!await ValidateAsync(user))
                return false;

            if (await _userRepository.UserNameExistsAsync(user.UserName))
                return _notificationHandler.AddNotification(EMessage.Exists.ToString(), EMessage.Exists.Description().FormatTo("UserName"));

            if(await _userRepository.EmailExistsAsync(user.Email))
                return _notificationHandler.AddNotification(EMessage.Exists.ToString(), EMessage.Exists.Description().FormatTo("Email"));

            return await _userRepository.InsertAsync(user);
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _userRepository.ExistsAsync(id);
    }
}
