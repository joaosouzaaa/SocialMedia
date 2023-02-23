namespace SocialMedia.Service.DataTransferObjects.Requests.Address
{
    public sealed class AddressSaveRequest
    {
        public required string ZipCode { get; set; }
        public required string Street { get; set; }
    }
}
