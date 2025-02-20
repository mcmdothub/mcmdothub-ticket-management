namespace TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for category details.
    /// Used in event-related queries to provide category information.
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the category.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
