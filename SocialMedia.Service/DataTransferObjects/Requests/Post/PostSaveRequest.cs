namespace SocialMedia.Service.DataTransferObjects.Requests.Post
{
    public sealed class PostSaveRequest
    {
        public required string Text { get; set; }
        public required int UserId { get; set; }
    }
}
