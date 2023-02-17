using SocialMedia.Domain.Entities.BaseEntities;

namespace SocialMedia.Domain.Entities
{
    public sealed class Tag : BaseEntity
    {
        public required string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}
