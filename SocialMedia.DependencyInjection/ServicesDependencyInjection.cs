using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Service.Interfaces.Services;
using SocialMedia.Service.Services;

namespace SocialMedia.DependencyInjection
{
    public static class ServicesDependencyInjection
    {
        public static void AddServicesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, UserService>();    
        }
    }
}
