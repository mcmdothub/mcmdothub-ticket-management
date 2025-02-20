namespace TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    /// <summary>
    /// Represents the detailed view model for an event.
    /// Used for retrieving complete event details in event queries.
    /// </summary>
    public class EventDetailVm
    {
        /// <summary>
        /// Gets or sets the unique identifier of the event.
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// Gets or sets the name/title of the event.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the event ticket.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the name of the performing artist.
        /// </summary>
        public string Artist { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the scheduled date and time of the event.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the description of the event.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL of the event's image/banner.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the category to which the event belongs.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category details associated with the event.
        /// </summary>
        public CategoryDto Category { get; set; } = new CategoryDto();
    }
}
