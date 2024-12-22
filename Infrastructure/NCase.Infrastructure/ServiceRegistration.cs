using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NCase.Application.Abstractions.Caching;
using NCase.Application.Abstractions.Services.Localization;
using NCase.Application.Abstractions.Storage;
using NCase.Application.Abstractions.Token;
using NCase.Application.Services;
using NCase.Infrastructure.Services;
using NCase.Infrastructure.Services.Storage;
using StackExchange.Redis;

namespace NCase.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IRedisCacheService, RedisCacheService>();
            serviceCollection.AddScoped<ILocalizationService, LocalizationService>();
            serviceCollection.AddTransient<IConnectionMultiplexer>(sp =>
            {
                var options = new ConfigurationOptions
                {
                    EndPoints = { configuration.GetConnectionString("RedisConnection") },
                    AbortOnConnectFail = false,
                    AsyncTimeout = 10000,
                    ConnectTimeout = 10000

                };
                return ConnectionMultiplexer.Connect(options);
            });
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
