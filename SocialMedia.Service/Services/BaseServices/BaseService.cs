using FluentValidation;
using SocialMedia.Business.Interfaces.Settings.NotificationSettings;

namespace SocialMedia.Service.Services.BaseServices
{
    public abstract class BaseService<TEntity>
        where TEntity : class
    {
        private readonly IValidator<TEntity> _validator;
        protected readonly INotificationHandler _notificationHandler;

        public BaseService(IValidator<TEntity> validator, INotificationHandler notificationHandler)
        {
            _validator = validator;
            _notificationHandler = notificationHandler;
        }

        protected async Task<bool> ValidateAsync(TEntity entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    _notificationHandler.AddNotification(error.PropertyName, error.ErrorMessage);

                return validationResult.IsValid;
            }

            return validationResult.IsValid;
        }
    }
}
