using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Contracts.Persistence
{
    /// <summary>
    /// Defines a repository contract for handling Category entities.
    /// Extends the generic IAsyncRepository interface to inherit common CRUD operations.
    /// </summary>
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        // Additional methods specific to Category can be added here if needed.
    }
}
