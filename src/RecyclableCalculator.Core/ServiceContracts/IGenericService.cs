using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.ServiceContracts
{
	public interface IGenericService<TModel, TAddDto, TUpdateDto, TResponseDto>
		where TModel : class
		where TAddDto : class
		where TUpdateDto : class
		where TResponseDto : class
	{

		/// <summary>
		/// Retrieves a list of all entities that match the specified filter.
		/// </summary>
		/// <param name="filter">A lambda expression used to filter the results.</param>
		/// <param name="includes">An array of navigation properties to include in the results.</param>
		/// <returns>A task that represents the asynchronous operation, containing a list of entities.</returns>
		Task<List<TResponseDto>> GetAllAsync(Expression<Func<TModel, bool>> filter = null,
			params string[] includes);

		/// <summary>
		/// Retrieves a single entity that matches the specified filter.
		/// </summary>
		/// <param name="filter">A lambda expression used to filter the results.</param>
		/// <param name="asNoTracking">A flag indicating whether to track the entity.</param>
		/// <param name="includes">An array of navigation properties to include in the results.</param>
		/// <returns>A task that represents the asynchronous operation, containing the entity.</returns>
		Task<TResponseDto> GetAsync(Expression<Func<TModel, bool>> filter, bool asNoTracking = true,
			params string[] includes);

		/// <summary>
		/// Retrieves a single entity by its ID.
		/// </summary>
		/// <param name="id">The ID of the entity to retrieve.</param>
		/// <param name="asNoTracking">A flag indicating whether to track the entity.</param>
		/// <param name="includes">An array of navigation properties to include in the results.</param>
		/// <returns>A task that represents the asynchronous operation, containing the entity.</returns>
		Task<TResponseDto> GetByIdAsync(int? id, bool asNoTracking = true, params string[] includes);

		/// <summary>
		/// Adds a new entity to the data store.
		/// </summary>
		/// <param name="addDto">The entity to add.</param>
		/// <returns>A task that represents the asynchronous operation, containing the added entity.</returns>
		Task<TResponseDto> AddAsync(TAddDto addDto);

		/// <summary>
		/// Updates an existing entity in the data store.
		/// </summary>
		/// <param name="updateDto">The entity to update.</param>
		/// <returns>A task that represents the asynchronous operation, containing the updated entity.</returns>
		Task<TResponseDto> UpdateAsync(TUpdateDto updateDto);

		/// <summary>
		/// Removes an entity from the data store.
		/// </summary>
		/// <param name="id">The ID of the entity to remove.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task RemoveAsync(int id);
	}
}
