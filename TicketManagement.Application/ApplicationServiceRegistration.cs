using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TicketManagement.Application
{
    /// <summary>
    /// Provides extension methods for registering application-layer services into the dependency injection container.
    /// Ensures that core application dependencies (AutoMapper, MediatR) are correctly configured.
    /// </summary>
    public static class ApplicationServiceRegistration
    {
        /// <summary>
        /// Registers application-level services, including AutoMapper and MediatR, into the provided <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The DI service collection to which dependencies will be added.</param>
        /// <param name="loggerFactory">The logger factory for logging during registration.</param>
        /// <returns>The modified <see cref="IServiceCollection"/> with registered services.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="services"/> is null.</exception>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ILoggerFactory loggerFactory)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));

            var logger = loggerFactory.CreateLogger("ApplicationServiceRegistration");

            try
            {
                logger.LogInformation("Registering AutoMapper...");

                // Register AutoMapper and scan all assemblies for profiles
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                logger.LogInformation("AutoMapper registered successfully.");

                logger.LogInformation("Registering MediatR...");

                // Register MediatR and scan all assemblies for MediatR handlers
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

                logger.LogInformation("MediatR registered successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while registering application services.");
                throw;
            }

            return services;
        }
    }
}