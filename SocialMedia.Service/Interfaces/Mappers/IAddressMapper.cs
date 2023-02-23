using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.Address;

namespace SocialMedia.Service.Interfaces.Mappers
{
    public interface IAddressMapper
    {
        Address SaveRequestToDomain(AddressSaveRequest addressSaveRequest);
    }
}
