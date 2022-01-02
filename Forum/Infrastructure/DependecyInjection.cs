using Application.Posts;
using Infrastructure.JsonPlaceHolderApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<JsonPlaceHolderClient>("JsonPlaceholderClient", config =>
            {
                config.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                config.Timeout = TimeSpan.FromSeconds(30);
            });

            services.AddTransient<IPostsApi, PostsApi>();

            return services;
        }
    }
}
