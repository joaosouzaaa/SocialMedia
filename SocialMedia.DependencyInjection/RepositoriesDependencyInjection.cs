using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Infra.Repositories;

namespace SocialMedia.DependencyInjection
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
