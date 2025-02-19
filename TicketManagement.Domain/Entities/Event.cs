using TicketManagement.Domain.Common;

namespace TicketManagement.Domain.Entities
{
    /// <summary>
    /// Represents an event within the ticket management system.
    /// Events belong to a specific category and contain details such as name, price, artist, date, and description.
    /// Inherits auditing properties from <see cref="AuditableEntity"/> for tracking creation and modifications.
    /// </summary>
    public class Event : AuditableEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the event.
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the event.
        /// This field is required and should not be null or empty.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the event ticket.
        /// The price must be a non-negative integer.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the artist or performer associated with the event.
        /// This field is optional and may be null for non-music events.
        /// </summary>
        public string? Artist { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the event.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets a brief description of the event.
        /// This field is optional and may be null.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the URL for the event's promotional image.
        /// This field is optional and may be null.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the category to which the event belongs.
        /// This property serves as a foreign key.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category associated with the event.
        /// This property establishes a relationship between the event and its category.
        /// </summary>
        public Category Category { get; set; } = default!;
    }
}
