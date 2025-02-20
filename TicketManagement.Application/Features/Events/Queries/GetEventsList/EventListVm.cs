namespace TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    /// <summary>
    /// ViewModel representing a lightweight summary of an event.
    /// This DTO (Data Transfer Object) is used for returning event lists 
    /// without exposing unnecessary details.
    /// </summary>
    public class EventListVm
    {
        /// <summary>
        /// Gets or sets the unique identifier of the event.
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the event.
        /// This should be a non-empty string representing the event title.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the event will take place.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the URL of the event's image.
        /// This can be used to display a thumbnail or promotional banner.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}
