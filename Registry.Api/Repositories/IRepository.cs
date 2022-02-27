using System.Linq.Expressions;

namespace Registry.Api.Repositories
{
	public interface IRepository<T> where T : class
	{
		Task Add(T entity);

		Task Update(T entity);

		Task Delete(T entity);

		Task<int> Count(Expression<Func<T, bool>>? predicate = null);

		Task<bool> Exists(Expression<Func<T, bool>> predicate);

		ValueTask<T?> GetById(object id);

		Task<T?> Get(Expression<Func<T, bool>> predicate);

		Task<T[]> List(int? skip = null, int? take = null);

		Task<T[]> List(Expression<Func<T, bool>> predicate, int? skip = null, int? take = null);

	}
}
