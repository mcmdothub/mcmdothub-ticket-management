using TicketManagement.Domain.Common;

namespace TicketManagement.Domain.Entities
{
    /// <summary>
    /// Represents a category of events in the ticket management system.
    /// Categories help classify different types of events (e.g., Music, Sports, Theater).
    /// Inherits auditing properties from <see cref="AuditableEntity"/> for tracking creation and modifications.
    /// </summary>
    public class Category : AuditableEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// This field is required and should not be null or empty.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of events associated with this category.
        /// Can be null if no events are currently linked to this category.
        /// </summary>
        public ICollection<Event>? Events { get; set; }
    }
}
