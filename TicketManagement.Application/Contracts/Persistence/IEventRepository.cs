using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Contracts.Persistence
{
    /// <summary>
    /// Defines a repository contract for handling Event entities.
    /// Extends the generic IAsyncRepository interface to inherit common CRUD operations.
    /// </summary>
    public interface IEventRepository: IAsyncRepository<Event>
    {
        // Additional methods specific to Event can be added here if needed.

    }
}
