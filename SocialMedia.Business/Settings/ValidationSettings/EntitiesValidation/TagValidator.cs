using FluentValidation;
using SocialMedia.Business.Enums;
using SocialMedia.Business.Extensions;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Settings.ValidationSettings.EntitiesValidation
{
    public sealed class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(t => t.Name).Length(1, 50)
                .WithMessage(t => string.IsNullOrEmpty(t.Name)
                ? EMessage.Required.Description().FormatTo("Name")
                : EMessage.WrongSize.Description().FormatTo("Name", "1 to 50"));
        }
    }
}
