namespace TicketManagement.Domain.Common
{
    // Base class "AuditableEntity"
    public class AuditableEntity
    {
        // will contain a number of base properties
        // I want every other entity to have full as a logging support for tracking purposes in my data store
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
