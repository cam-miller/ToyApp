using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToyApp.Infrastructure.Persistence;
using ToyApp.Infrastructure.Repositories;

namespace ToyApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddToyAppInfrastructure(this IServiceCollection services)
    {
        // add db context;
        services.AddDbContext<ToyAppContext>();
        // adding the repositories would happen here.
        services.AddScoped<ITodoRepository, TodoRepository>();
        return services;
    }
}