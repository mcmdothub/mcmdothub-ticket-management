using AutoMapper;
using Microsoft.Extensions.Logging;
using TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.Application.Features.Events.Queries.GetEventsList;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Profiles
{
    /// <summary>
    /// Defines the AutoMapper mapping configuration for domain entities and DTOs.
    /// This class ensures proper transformation between different layers of the application.
    /// </summary>
    public class MappingProfile : Profile
    {
        private readonly ILogger<MappingProfile> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// Sets up object mappings between domain entities and their corresponding DTOs.
        /// </summary>
        /// <param name="logger">The logger instance used for logging mapping configuration status.</param>
        public MappingProfile(ILogger<MappingProfile> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            try
            {
                _logger.LogInformation("Initializing mapping configurations.");

                // Maps Event entity to EventListVm DTO and vice versa
                CreateMap<Event, EventListVm>().ReverseMap();

                // Maps Event entity to EventDetailVm DTO and vice versa
                CreateMap<Event, EventDetailVm>().ReverseMap();

                // Maps Category entity to CategoryDto DTO and vice versa
                CreateMap<Category, CategoryDto>().ReverseMap();

                _logger.LogInformation("Mapping configurations successfully initialized.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while setting up AutoMapper profiles.");
                throw;
            }
        }
    }
}
