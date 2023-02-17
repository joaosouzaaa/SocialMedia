namespace SocialMedia.Service.DataTransferObjects.Requests
{
    public sealed class PostSaveRequest
    {
        public required string Text { get; set; }
        public required int UserId { get; set; }
    }
}
