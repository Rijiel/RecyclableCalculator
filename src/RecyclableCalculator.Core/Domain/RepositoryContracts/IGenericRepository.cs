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
		Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes);

		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = true, params string[] includes);

		Task<TEntity> GetByIdAsync(int id, bool asNoTracking = true, params string[] includes);

		Task SaveChangesAsync();

		void Add(TEntity entity);

		void Remove(TEntity entity);
	}
}
