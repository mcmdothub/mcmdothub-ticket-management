using MediatR;

namespace TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    /// <summary>
    /// Represents a query to retrieve a list of events.
    /// This query is handled using the CQRS (Command Query Responsibility Segregation) pattern.
    /// </summary>
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
        // No additional parameters needed for now.
        // If filtering or sorting is required in the future, add properties here.
    }
}
