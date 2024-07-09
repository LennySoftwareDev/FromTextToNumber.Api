using FromNumberToText.Domain.User;
using FromNumberToText.Persistence.FromNumberToText;
using Microsoft.Extensions.DependencyInjection;

namespace FromNumberToText.Persistence.User;

public static class UserRepositoryConfiguration
{
    public static void ConfigurationUserRepository(this IServiceCollection services) =>
    services.AddScoped<IUserRepository, UserRepository>();
}
