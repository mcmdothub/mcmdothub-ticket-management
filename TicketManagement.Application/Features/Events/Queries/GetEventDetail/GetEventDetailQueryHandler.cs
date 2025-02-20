using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    /// <summary>
    /// Handles the <see cref="GetEventDetailQuery"/> request and returns detailed information about an event.
    /// Implements the MediatR IRequestHandler for the <see cref="GetEventDetailQuery"/>.
    /// </summary>
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEventDetailQueryHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEventDetailQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for mapping domain entities to view models.</param>
        /// <param name="eventRepository">The repository interface for retrieving event data.</param>
        /// <param name="categoryRepository">The repository interface for retrieving category data.</param>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <exception cref="ArgumentNullException">Thrown if any of the dependencies are null.</exception>
        public GetEventDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<Event> eventRepository,
            IAsyncRepository<Category> categoryRepository,
            ILogger<GetEventDetailQueryHandler> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Handles the <see cref="GetEventDetailQuery"/> request by fetching event details and its associated category.
        /// </summary>
        /// <param name="request">The <see cref="GetEventDetailQuery"/> request object containing the event ID.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>An <see cref="EventDetailVm"/> object containing the event details.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while retrieving or mapping the event data.</exception>
        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching event details for event ID: {EventId}", request.Id);

                // Retrieve the event from the repository
                var @event = await _eventRepository.GetByIdAsync(request.Id);

                if (@event == null)
                {
                    _logger.LogWarning("Event with ID {EventId} not found.", request.Id);
                    return null; // Return null or throw a NotFoundException depending on your error handling strategy
                }

                // Map the event to the view model
                var eventDetailVm = _mapper.Map<EventDetailVm>(@event);

                // Retrieve the associated category
                var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

                if (category == null)
                {
                    _logger.LogWarning("Category with ID {CategoryId} for event ID {EventId} not found.", @event.CategoryId, request.Id);
                }
                else
                {
                    // Map the category to the DTO
                    eventDetailVm.Category = _mapper.Map<CategoryDto>(category);
                }

                _logger.LogInformation("Successfully retrieved event details for event ID: {EventId}", request.Id);

                return eventDetailVm;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving event details for event ID: {EventId}", request.Id);
                throw; // Rethrow the exception to let the pipeline handle it
            }
        }
    }
}
