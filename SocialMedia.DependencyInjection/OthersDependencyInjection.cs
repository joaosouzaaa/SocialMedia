using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Business.Interfaces.Settings.NotificationSettings;
using SocialMedia.Business.Settings.NotificationSettings;

namespace SocialMedia.DependencyInjection
{
    public static class OthersDependencyInjection
    {
        public static void AddOtherDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler, NotificationHandler>();
        }
    }
}
