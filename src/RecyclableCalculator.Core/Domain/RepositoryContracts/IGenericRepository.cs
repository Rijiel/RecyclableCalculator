using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Domain.RepositoryContracts
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Retrieves a list of entities that match the specified filter.
		/// </summary>
		/// <param name="filter">A lambda expression used to filter the entities.</param>
		/// <param name="includes">An array of navigation properties to include in the query.</param>
		/// <returns>A task that represents the asynchronous operation, containing a list of entities.</returns>
		Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes);

		/// <summary>
		/// Retrieves a single entity that matches the specified filter.
		/// </summary>
		/// <param name="filter">A lambda expression used to filter the entities.</param>
		/// <param name="asNoTracking">A flag indicating whether to track the entity or not.</param>
		/// <param name="includes">An array of navigation properties to include in the query.</param>
		/// <returns>A task that represents the asynchronous operation, containing the entity.</returns>
		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = true, params string[] includes);

		/// <summary>
		/// Retrieves an entity by its ID.
		/// </summary>
		/// <param name="id">The ID of the entity to retrieve.</param>
		/// <param name="asNoTracking">A flag indicating whether to track the entity or not.</param>
		/// <param name="includes">An array of navigation properties to include in the query.</param>
		/// <returns>A task that represents the asynchronous operation, containing the entity.</returns>
		Task<TEntity> GetByIdAsync(int id, bool asNoTracking = true, params string[] includes);

		/// <summary>
		/// Saves all changes made to the entities.
		/// </summary>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task SaveChangesAsync();

		/// <summary>
		/// Adds a new entity to the context.
		/// </summary>
		/// <param name="entity">The entity to add.</param>
		void Add(TEntity entity);

		/// <summary>
		/// Removes an entity from the context.
		/// </summary>
		/// <param name="entity">The entity to remove.</param>
		void Remove(TEntity entity);
	}
}
