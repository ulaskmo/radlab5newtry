using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace radlab5._1.Data
{
    public class FluentUserDbContextFactory : IDesignTimeDbContextFactory<FluentUserDbContext>
    {
        public FluentUserDbContext CreateDbContext(string[] args)
        {
            // Configure the context options
            var optionsBuilder = new DbContextOptionsBuilder<FluentUserDbContext>();

            // Get the configuration from the appsettings.json file
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Configure SQLite with the connection string
            var connectionString = configuration.GetConnectionString("FluentUserDatabase");
            optionsBuilder.UseSqlite(connectionString);

            return new FluentUserDbContext(optionsBuilder.Options);
        }
    }
}