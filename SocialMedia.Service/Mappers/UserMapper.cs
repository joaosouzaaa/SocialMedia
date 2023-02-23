using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.User;
using SocialMedia.Service.Interfaces.Mappers;

namespace SocialMedia.Service.Mappers
{
    public sealed class UserMapper : IUserMapper
    {
        private readonly IAddressMapper _addressMapper;

        public UserMapper(IAddressMapper addressMapper)
        {
            _addressMapper = addressMapper;
        }

        public User SaveRequestToDomain(UserSaveRequest userSaveRequest)
        {
            var address = _addressMapper.SaveRequestToDomain(userSaveRequest.Address);

            return new User()
            {
                Address = address,
                Email = userSaveRequest.Email,
                UserName = userSaveRequest.UserName
            };
        }
    }
}
