using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories.ReadRepositories;

public interface IAsyncReadRepository<TypeEntity> : IQuery<TypeEntity> where TypeEntity : BaseEntity {
	Task<TypeEntity?> GetAsync(Expression<Func<TypeEntity, Boolean>> predicate);
	Task<TypeEntity?> GetByIdAsync(Guid id);
	Task<IPaginate<TypeEntity>> GetListAsync(
									Expression<Func<TypeEntity, Boolean>>? predicate = null,
									Func<IQueryable<TypeEntity>, IOrderedQueryable<TypeEntity>>? orderBy = null,
									Func<IQueryable<TypeEntity>, IIncludableQueryable<TypeEntity, Object>>? include = null,
									Int32 index = 0, Int32 size = 10, Boolean enableTracking = true,
									CancellationToken cancellationToken = default
		);

	Task<IPaginate<TypeEntity>> GetListByDynamicAsync(
									Dynamic.Dynamic dynamic,
									Func<IQueryable<TypeEntity>, IIncludableQueryable<TypeEntity, Object>>? include = null,
									Int32 index = 0, Int32 size = 10, Boolean enableTracking = true,
									CancellationToken cancellationToken = default
		);
}