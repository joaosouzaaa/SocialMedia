using FluentValidation;
using SocialMedia.Business.Enums;
using SocialMedia.Business.Extensions;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Settings.ValidationSettings.EntitiesValidation
{
    public sealed class LikeValidator : AbstractValidator<Like>
    {
        public LikeValidator()
        {
            RuleFor(l => l.UserId).NotEmpty()
                .WithMessage(EMessage.Required.Description().FormatTo("User id"));

            RuleFor(l => l.PostId).NotEmpty()
                .WithMessage(EMessage.Required.Description().FormatTo("Post id"));
        }
    }
}
