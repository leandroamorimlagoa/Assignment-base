using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Assignment.Infrastructure.Data.DesignTimeDbContextFactories;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var waitForSeconds = 30;
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("data source=AssignmentDb.db", t=>t.CommandTimeout(waitForSeconds));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
