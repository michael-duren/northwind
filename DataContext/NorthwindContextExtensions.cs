using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataContext;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the SqlServer database provider.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="connectionString">Set to override the default.</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services, // The type to extend.
        string? connectionString = null)
    {
        if (connectionString is null)
        {
            SqlConnectionStringBuilder builder = new();

            builder.DataSource = "localhost";
            builder.InitialCatalog = "Northwind";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;

            // Because we want to fail faster. Default is 15 seconds.
            builder.ConnectTimeout = 3;

            builder.UserID = Environment.GetEnvironmentVariable("MY_SQL_USER");
            builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PASSWORD");


            connectionString = builder.ConnectionString;
        }

        services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(connectionString);

                options.LogTo(NorthwindContextLogger.WriteLine,
                    new[]
                    {
                        Microsoft.EntityFrameworkCore
                            .Diagnostics.RelationalEventId.CommandExecuting
                    });
            },
            // Register with a transient lifetime to avoid concurrency 
            // issues with Blazor Server projects.
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient);

        return services;
    }
}