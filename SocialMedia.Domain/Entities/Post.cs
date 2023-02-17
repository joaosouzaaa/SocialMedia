using SocialMedia.Domain.Entities.BaseEntities;

namespace SocialMedia.Domain.Entities
{
    public sealed class Post : BaseEntity
    {
        public required string Text { get; set; }

        public required int UserId { get; set; }
        public User User { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Like> Likes { get; set; }
    }
}
