using FluentValidation;
using SocialMedia.Business.Enums;
using SocialMedia.Business.Extensions;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Business.Settings.ValidationSettings.EntitiesValidation 
{
    public sealed class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.ZipCode).Length(8)
                .WithMessage(EMessage.WrongSize.Description().FormatTo("Zip Code", "8"));

            RuleFor(a => a.Street).Length(3, 50)
                .WithMessage(EMessage.WrongSize.Description().FormatTo("Street", "3 to 50."));
        }
    }
}
