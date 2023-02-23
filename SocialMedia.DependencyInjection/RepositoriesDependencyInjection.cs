using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Business.Interfaces.Repositories;
using SocialMedia.Infra.Repositories;
using SocialMedia.Service.Interfaces.Mappers;
using SocialMedia.Service.Mappers;

namespace SocialMedia.DependencyInjection
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
