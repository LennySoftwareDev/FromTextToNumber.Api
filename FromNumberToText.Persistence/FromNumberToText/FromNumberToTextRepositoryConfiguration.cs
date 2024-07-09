using FromNumberToText.Domain.FromNumberToText;
using Microsoft.Extensions.DependencyInjection;

namespace FromNumberToText.Persistence.FromNumberToText;

public static class FromNumberToTextRepositoryConfiguration
{
    public static void ConfigurationFromNumberToTextRepository(this IServiceCollection services)
    {
        services.AddScoped<IFromNumberToTextRepository, FromNumberToTextRepository>();
    }
}
