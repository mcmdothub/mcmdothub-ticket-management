using TicketManagement.Domain.Common;

namespace TicketManagement.Domain.Entities
{
    // Inherit from AuditableEntity
    public class Category: AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Event>? Events { get; set; }
    }
}