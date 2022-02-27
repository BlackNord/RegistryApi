using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Registry.Api.Repositories
{
	public class EntityFrameworkRepository<T> : IRepository<T> where T : class
	{
		private readonly DbContext dbContext;

		private DbSet<T> EntitiesSet => dbContext.Set<T>();

		public EntityFrameworkRepository(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task Add(T entity)
		{
			await EntitiesSet.AddAsync(entity);
			await dbContext.SaveChangesAsync();
		}

		public async Task Update(T entity)
		{
			EntitiesSet.Update(entity);
			await dbContext.SaveChangesAsync();
		}

		public async Task Delete(T entity)
		{
			EntitiesSet.Remove(entity);
			await dbContext.SaveChangesAsync();
		}

		public Task<int> Count(Expression<Func<T, bool>>? predicate = null)
		{
			if (predicate == null)
			{
				return EntitiesSet.CountAsync();
			}

			var entities = EntitiesSet.Where(predicate);
			return entities.CountAsync();
		}

		public Task<bool> Exists(Expression<Func<T, bool>> predicate)
		{
			var result = EntitiesSet.AnyAsync(predicate);
			return result;
		}

		public async ValueTask<T?> GetById(object id)
		{
			var result = await EntitiesSet.FindAsync(id);
			return result;
		}

		public Task<T?> Get(Expression<Func<T, bool>> predicate)
		{
			var result = EntitiesSet.FirstOrDefaultAsync(predicate);
			return result;
		}

		public Task<T[]> List(int? skip = null, int? take = null)
		{
			var result = List(EntitiesSet, skip, take);
			return result;
		}

		public Task<T[]> List(Expression<Func<T, bool>> predicate, int? skip = null, int? take = null)
		{
			var entities = EntitiesSet.Where(predicate);

			var result = List(entities, skip, take);
			return result;
		}

		private async Task<T[]> List(IQueryable<T> entities, int? skip = null, int? take = null)
		{
			if (skip.HasValue)
			{
				entities = entities.Skip(skip.Value);
			}

			if (take.HasValue)
			{
				entities = entities.Take(take.Value);
			}

			var result = await entities.ToArrayAsync();
			return result;
		}
	}
}
