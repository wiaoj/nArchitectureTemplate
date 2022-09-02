using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories.ReadRepositories;

public interface IReadRepository<TypeEntity> : IQuery<TypeEntity> where TypeEntity : BaseEntity {
	TypeEntity Get(Expression<Func<TypeEntity, Boolean>> predicate);

	IPaginate<TypeEntity> GetList(
							Expression<Func<TypeEntity, Boolean>>? predicate = null,
							Func<IQueryable<TypeEntity>, IOrderedQueryable<TypeEntity>>? orderBy = null,
							Func<IQueryable<TypeEntity>, IIncludableQueryable<TypeEntity, Object>>? include = null,
							Int32 index = 0, Int32 size = 10,
							Boolean enableTracking = true
		);

	IPaginate<TypeEntity> GetListByDynamic(
							Dynamic.Dynamic dynamic,
							Func<IQueryable<TypeEntity>, IIncludableQueryable<TypeEntity, Object>>? include = null,
							Int32 index = 0,
							Int32 size = 10,
							Boolean enableTracking = true
		);
}