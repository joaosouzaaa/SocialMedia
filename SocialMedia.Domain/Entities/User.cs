using SocialMedia.Domain.Entities.BaseEntities;

namespace SocialMedia.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
