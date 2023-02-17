using SocialMedia.Business.Settings.NotificationSettings;

namespace SocialMedia.Business.Interfaces.Settings.NotificationSettings
{
    public interface INotificationHandler
    {
        List<DomainNotification> GetAllNotifications();
        bool AddNotification(string key, string message);
    }
}
