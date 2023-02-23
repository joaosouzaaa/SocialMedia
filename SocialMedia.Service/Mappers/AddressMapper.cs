using SocialMedia.Domain.Entities;
using SocialMedia.Service.DataTransferObjects.Requests.Address;
using SocialMedia.Service.Interfaces.Mappers;

namespace SocialMedia.Service.Mappers
{
    public sealed class AddressMapper : IAddressMapper
    {
        public Address SaveRequestToDomain(AddressSaveRequest addressSaveRequest) =>
            new Address()
            {
                Street = addressSaveRequest.Street,
                ZipCode = addressSaveRequest.ZipCode
            };
    }
}
