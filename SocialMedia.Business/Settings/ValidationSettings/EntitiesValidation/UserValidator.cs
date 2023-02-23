using FluentValidation;
using SocialMedia.Business.Enums;
using SocialMedia.Business.Extensions;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Settings.ValidationSettings.EntitiesValidation
{
    public sealed class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Address).SetValidator(new AddressValidator());

            RuleFor(u => u.UserName).Length(1, 50)
                .WithMessage(EMessage.WrongSize.Description().FormatTo("UserName", "1 to 50"));

            RuleFor(u => u.Email).EmailAddress()
                .WithMessage(EMessage.WrongFormat.Description().FormatTo("Email"));
        }
    }
}
