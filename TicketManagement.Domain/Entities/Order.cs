using TicketManagement.Domain.Common;

namespace TicketManagement.Domain.Entities
{
    /// <summary>
    /// Represents an order placed by a user in the ticket management system.
    /// This entity contains details about the user, order amount, order status, and timestamps.
    /// Inherits auditing properties from <see cref="AuditableEntity"/> for tracking creation and modifications.
    /// </summary>
    public class Order : AuditableEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who placed the order.
        /// This serves as a foreign key linking the order to a specific user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the order.
        /// The value should always be a non-negative integer representing the total cost of the tickets.
        /// </summary>
        public int OrderTotal { get; set; }

        /// <summary>
        /// Gets or sets the timestamp indicating when the order was placed.
        /// This value is automatically recorded at the time of order creation.
        /// </summary>
        public DateTime OrderPlaced { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the order has been paid.
        /// A value of <c>true</c> means the order is fully paid, while <c>false</c> indicates pending payment.
        /// </summary>
        public bool OrderPaid { get; set; }
    }
}
