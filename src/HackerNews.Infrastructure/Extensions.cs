using HackerNews.Application.Abstractions;
using HackerNews.Infrastructure.DAL;
using HackerNews.Infrastructure.DAL.Cache;
using HackerNews.Infrastructure.Middleware;
using HackerNews.Infrastructure.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HackerNews.Infrastructure;

public static class Extensions
{
    private const string DataOptionsSectionName = "Data";
    private const string CacheOptionsSectionName = "Cache";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureOptions(configuration)
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddHttpClient()
            .AddMemoryCache()
            .AddSingleton<IHackerNewsHttpClientContext, HackerNewsHttpClientContext>()
            .AddSingleton<IDataCache, MemoryDataCache>()
            .AddSingleton<ExceptionMiddleware>()
            .AddQueryHandlers();

        services.AddControllers();
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();
        return app;
    }

    private static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(typeof(Extensions).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }

    private static IServiceCollection AddInfrastructureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DataOptions>(configuration.GetRequiredSection(DataOptionsSectionName));
        services.Configure<CacheOptions>(configuration.GetRequiredSection(CacheOptionsSectionName));
        return services;
    }
}