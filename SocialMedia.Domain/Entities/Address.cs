using SocialMedia.Domain.Entities.BaseEntities;

namespace SocialMedia.Domain.Entities
{
    public sealed class Address : BaseEntity
    {
        public required string ZipCode { get; set; }
        public required string Street { get; set; }
    }
}
