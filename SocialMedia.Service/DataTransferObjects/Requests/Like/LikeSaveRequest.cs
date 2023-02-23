namespace SocialMedia.Service.DataTransferObjects.Requests.Like
{
    public sealed class LikeSaveRequest
    {
        public required int UserId { get; set; }
        public required int PostId { get; set; }
    }
}
