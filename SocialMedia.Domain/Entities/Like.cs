using SocialMedia.Domain.Entities.BaseEntities;

namespace SocialMedia.Domain.Entities
{
    public sealed class Like : BaseEntity
    {
        public required int UserId { get; set; }
        public User User { get; set; }
        public required int PostId { get; set; }
        public Post Post { get; set; } 
    }
}
