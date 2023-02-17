using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Service.Interfaces.Mappers;
using SocialMedia.Service.Mappers;

namespace SocialMedia.DependencyInjection
{
    public static class MapperDependencyInjection
    {
        public static void AddMapperDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPostMapper, PostMapper>();
        }
    }
}
