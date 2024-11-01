using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;

namespace Notes.Persistence;

public static class DependencyInjection
{
    private const string DbConnection = "DbConnection";

    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[DbConnection];
        services.AddDbContext<NotesDbContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<INotesDbContext>(provider =>
            provider.GetService<NotesDbContext>() ??
            throw new InvalidOperationException($"Не найден сервис {nameof(NotesDbContext)}"));
    }
}