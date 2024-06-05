using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Infrastructure.Data.Extensions;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}
