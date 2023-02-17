using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Business.Interfaces.Settings.NotificationSettings;

namespace SocialMedia.Api.Filters
{
    public sealed class NotificationFilter : ActionFilterAttribute
    {
        private readonly INotificationHandler _notificationHandler;

        public NotificationFilter(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var notificationList = _notificationHandler.GetAllNotifications();

            if (notificationList.Any())
                context.Result = new BadRequestObjectResult(notificationList);

            base.OnActionExecuted(context);
        }
    }
}
