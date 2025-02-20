using MediatR;

namespace TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    /// <summary>
    /// Represents the request to retrieve detailed information about a specific event.
    /// Implements the MediatR <see cref="IRequest{TResponse}"/> interface to handle event details retrieval.
    /// </summary>
    public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the event to be retrieved.
        /// </summary>
        public Guid Id { get; set; }
    }
}
