using Assignment.Domain.Constants;
using Assignment.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Assignment.Infrastructure.Data.Seeds;
internal static class IdentitySeedExtensions
{
    internal static async Task SeedIdentityAsync(this UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        if (roleManager.Roles.Any())
        {
            return;
        }

        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }
    }
}
