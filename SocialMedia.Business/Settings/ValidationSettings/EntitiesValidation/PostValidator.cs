using FluentValidation;
using SocialMedia.Business.Enums;
using SocialMedia.Business.Extensions;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Settings.ValidationSettings.EntitiesValidation
{
    public sealed class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Text).Length(1, 300)
                .WithMessage(p => string.IsNullOrEmpty(p.Text)
                ? EMessage.Required.Description().FormatTo("Text")
                : EMessage.WrongSize.Description().FormatTo("Text", "1 to 300"));
        }
    }
}
