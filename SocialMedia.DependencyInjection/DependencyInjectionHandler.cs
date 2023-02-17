using Microsoft.Extensions.DependencyInjection;

namespace SocialMedia.DependencyInjection
{
    public static class DependencyInjectionHandler
    {
        public static void AddDependencyInjectionHandler(this IServiceCollection services)
        {
            services.AddOtherDependencyInjection();
            services.AddRepositoriesDependencyInjection();
            services.AddValidatorDependencyInjection();
            services.AddMapperDependencyInjection();
            services.AddServicesDependencyInjection();
        }
    }
}
