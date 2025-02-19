using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Contracts.Persistence
{
    /// <summary>
    /// Defines a repository contract for handling Order entities.
    /// Extends the generic IAsyncRepository interface to inherit common CRUD operations.
    /// </summary>
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        // Additional methods specific to Order can be added here if needed.

    }
}
