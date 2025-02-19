namespace TicketManagement.Application.Contracts.Persistence
{
    /// <summary>
    /// Defines a generic asynchronous repository interface for performing CRUD operations(Create, Read, Update, Delete) 
    /// for any entity type (T).
    /// It provides an abstraction layer to decouple data access logic from business logic.
    /// </summary>
    /// <typeparam name="T">The entity type that this repository will manage.</typeparam>
    public interface IAsyncRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves an entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier (GUID) of the entity.</param>
        /// <returns>The entity if found, otherwise null.</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all entities of type T asynchronously.
        /// </summary>
        /// <returns>A read-only list containing all entities.</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Adds a new entity to the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>The added entity, including its generated identifiers (if applicable).</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity in the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity containing updated values.</param>
        /// <remarks>Ensure that the entity exists before calling this method.</remarks>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity from the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        /// <remarks>Ensure that the entity exists before calling this method to prevent exceptions.</remarks>
        Task DeleteAsync(T entity);
    }
}
