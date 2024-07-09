using Application.Core.Base.Mapper.Configuration;
using Application.Core.LoginUser.Utils;
using FromNumberToText.Persistence.Context;
using FromNumberToText.Persistence.FromNumberToText;
using FromNumberToText.Persistence.User;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Core;

public static class ApplicationServiceConfiguration
{
    public static void ConfigurationApplicationService(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<CreateToken>();
        services.ConfigureMapper();
        services.ConfigurationFromNumberToTextRepository();
        services.ConfigurationUserRepository();
        services.ConfigurationPersistenceDbContext(connectionString);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
