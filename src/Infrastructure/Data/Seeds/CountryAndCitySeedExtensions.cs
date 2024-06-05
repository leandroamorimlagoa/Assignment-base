using Assignment.Domain.Entities;

namespace Assignment.Infrastructure.Data.Seeds;
internal static class CountryAndCitySeedExtensions
{
    internal static async Task TryToSeedCountryAndCity(this ApplicationDbContext context)
    {
        if (context.Countries.Any())
        {
            return;
        }

        await context.Countries.AddRangeAsync(new Country
        {
            Name = "Portugal",
            Cities =
                {
                    new City { Name = "Lisbon" },
                    new City { Name = "Porto" }
                }
        },
        new Country
        {
            Name = "Germany",
            Cities =
            {
                new City { Name = "Berlin" },
                new City { Name = "Neuenhagen" }
            }
        },
        new Country
        {
            Name = "Australia",
            Cities =
                {
                    new City { Name = "Sydney" },
                    new City { Name = "Melbourne" },
                    new City { Name = "Brisbane" },
                }
        });

        await context.SaveChangesAsync();
    }
}
