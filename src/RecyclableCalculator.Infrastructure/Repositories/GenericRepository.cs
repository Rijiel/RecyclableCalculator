using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Infrastructure.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
		{
			IQueryable<TEntity> query = _dbSet;

			// Disable tracking by default to prevent unnecessary updates and errors
			query = query.AsNoTracking();

			// Apply filter
			if (filter != null)
			{
				query = query.Where(filter);
			}

			// Apply each include
			if (includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			return await query.ToListAsync();
		}

		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = true, params string[] includes)
		{
			IQueryable<TEntity> query = _dbSet;

			// Disable tracking by default to prevent unnecessary updates and errors
			query = asNoTracking ? query.AsNoTracking() : query;

			// Apply filter
			if (filter != null)
			{
				query = query.Where(filter);
			}

			// Apply each include
			if (includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			return await query.FirstOrDefaultAsync();
		}

		public async Task<TEntity> GetByIdAsync(int id, bool asNoTracking = true, params string[] includes)
		{
			IQueryable<TEntity> query = _dbSet;

			// Disable tracking by default to prevent unnecessary updates and errors
			query = asNoTracking ? query.AsNoTracking() : query;

			// Apply each include
			if (includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			// Use reflection to get the Id property of the generic model
			var key = typeof(TEntity).GetProperty("Id");

			return await query.FirstOrDefaultAsync(x => key.GetValue(x).Equals(id));
		}

		public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

		public void Add(TEntity entity) => _dbSet.Add(entity);

		public void Remove(TEntity entity) => _dbSet.Remove(entity);
	}
}
