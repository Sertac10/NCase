using NCase.Application.Abstractions.Security;
using NCase.Application.Common.Specifications;
using NCase.Application.Common.Validators;
using NCase.Application.Services;

namespace NCase.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddMediatR(typeof(ServiceRegistration));
            serviceCollection.AddHttpClient();
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddLocalization();
            //otomatize et -->

            serviceCollection.AddScoped<CharacterSpecifications>();
            serviceCollection.AddScoped<DbParameterSpecifications>();
            serviceCollection.AddScoped<DbParameterTypeSpecifications>();
            serviceCollection.AddScoped<ErrorSpecifications>();
            serviceCollection.AddScoped<UserSpecifications>();
            serviceCollection.AddScoped<ICryptographyService, CryptographyService>();

        }
    }
}