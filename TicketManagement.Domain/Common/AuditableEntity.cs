namespace TicketManagement.Domain.Common
{
    /// <summary>
    /// Represents a base class for entities that require auditing metadata such as 
    /// creation and modification tracking. This class provides standardized fields 
    /// to support entity tracking in a data store.
    /// </summary>
    public class AuditableEntity
    {
        /// <summary>
        /// Gets or sets the username or identifier of the user who created the entity.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// This field is mandatory and should be set when the entity is persisted.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the username or identifier of the user who last modified the entity.
        /// Can be null if the entity has never been modified after creation.
        /// </summary>
        public string? LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last modified.
        /// Can be null if the entity has never been modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}
