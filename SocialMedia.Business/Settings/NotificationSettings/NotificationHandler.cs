using SocialMedia.Business.Interfaces.Settings.NotificationSettings;

namespace SocialMedia.Business.Settings.NotificationSettings
{
    public sealed class NotificationHandler : INotificationHandler
    {
        private readonly List<DomainNotification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public bool AddNotification(string key, string message)
        {
            var domainNotification = new DomainNotification() 
            { 
                Key = key, 
                Message = message 
            };

            _notifications.Add(domainNotification);

            return false;
        }

        public List<DomainNotification> GetAllNotifications() =>
            _notifications;
    }
}
