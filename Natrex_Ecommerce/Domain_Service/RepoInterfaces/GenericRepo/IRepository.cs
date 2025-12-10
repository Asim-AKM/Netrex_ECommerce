
namespace Domain_Service.RepoInterfaces.GenericRepo
{
    /// <summary>
    /// Represents a generic repository interface that defines 
    /// the standard CRUD (Create, Read, Update, Delete) operations 
    /// for any entity in the application.
    /// </summary>
    /// <typeparam name="T">
    /// The type of entity for which the repository is created.
    /// Must be a reference type (class).
    /// </typeparam>
    /// <remarks>
    /// This interface is used as a base for all repository interfaces 
    /// to ensure consistency and reusability across the application.
    /// It abstracts the data access layer and promotes loose coupling.
    /// </remarks>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Inserts a new entity into the database.
        /// </summary>
        /// <param name="obj">
        /// The entity instance that needs to be created.
        /// </param>
        /// <returns>
        /// Returns the created entity after successful insertion.
        /// </returns>
        Task<T> Create(T obj);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="obj">
        /// The entity instance with updated values.
        /// </param>
        /// <returns>
        /// Returns the updated entity after the operation completes.
        /// </returns>
        Task<T> Update(T obj);

        /// <summary>
        /// Deletes an existing entity from the database.
        /// </summary>
        /// <param name="obj">
        /// The entity instance that needs to be deleted.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if the entity was successfully deleted; 
        /// otherwise <c>false</c>.
        /// </returns>
        Task<bool> Delete(T obj);
        Task<T> GetById(Guid id);

        Task SaveChangesAsync();
    }
}

