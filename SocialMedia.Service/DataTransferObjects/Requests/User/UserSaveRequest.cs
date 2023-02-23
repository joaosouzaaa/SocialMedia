using SocialMedia.Service.DataTransferObjects.Requests.Address;

namespace SocialMedia.Service.DataTransferObjects.Requests.User
{
    public sealed class UserSaveRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public AddressSaveRequest Address { get; set; }
    }
}
