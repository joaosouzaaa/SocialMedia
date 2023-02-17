using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Business.Settings.ValidationSettings.EntitiesValidation;
using SocialMedia.Domain.Entities;

namespace SocialMedia.DependencyInjection
{
    public static class ValidatorDependencyInjection
    {
        public static void AddValidatorDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Post>, PostValidator>();
            services.AddScoped<IValidator<Tag>, TagValidator>();
        }
    }
}
