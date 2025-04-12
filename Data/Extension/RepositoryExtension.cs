using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extension;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
