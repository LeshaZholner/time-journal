using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeJournal.DbContexts;
using TimeJournal.Repositories;

namespace TimeJournal;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddTimeJournalDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null)
    {
        return services
            .AddDbContext<TimeJournalDbContext>(optionsAction);
    }
    public static IServiceCollection AddTimeJournalServices(this IServiceCollection services)
    {
        services
            .AddScoped<IProjectRepository, ProjectRepository>();

        return services;
    }
}

