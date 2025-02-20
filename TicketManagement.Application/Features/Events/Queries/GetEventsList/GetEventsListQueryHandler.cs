using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    /// <summary>
    /// Handles the <see cref="GetEventsListQuery"/> request and returns a list of <see cref="EventListVm"/> objects.
    /// Implements the MediatR IRequestHandler for the GetEventsListQuery.
    /// </summary>
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEventsListQueryHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEventsListQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for mapping domain entities to view models.</param>
        /// <param name="eventRepository">The repository interface for retrieving event data.</param>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <exception cref="ArgumentNullException">Thrown if any of the dependencies are null.
        public GetEventsListQueryHandler(IMapper mapper, 
            IAsyncRepository<Event> eventRepository,
            ILogger<GetEventsListQueryHandler> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Handles the <see cref="GetEventsListQuery"/> request by fetching all events from the repository,
        /// ordering them by date, and mapping them to a list of <see cref="EventListVm"/> objects.
        /// </summary>
        /// <param name="request">The <see cref="GetEventsListQuery"/> request object.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A read-only list of <see cref="EventListVm"/> objects representing the events.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while fetching or mapping the events.</exception>
        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching all events from the repository.");

                // Retrieve all events from the repository
                var allEvents = await _eventRepository.ListAllAsync();

                // Log if the repository returns null or empty list
                if (allEvents == null || !allEvents.Any())
                {
                    _logger.LogWarning("No events found in the repository.");
                    return new List<EventListVm>(); // Return an empty list instead of null
                }

                // Order the events by date before returning
                var orderedEvents = allEvents.OrderBy(x => x.Date);

                // Map the domain entities to view models
                var eventList = _mapper.Map<List<EventListVm>>(orderedEvents);

                _logger.LogInformation("Successfully retrieved {EventCount} events.", eventList.Count);

                return eventList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving event list.");
                throw; // Rethrow the exception to let the pipeline handle it
            }
        }
    }
}
