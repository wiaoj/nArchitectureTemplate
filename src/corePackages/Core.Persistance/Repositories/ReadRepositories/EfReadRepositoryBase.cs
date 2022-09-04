using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories.ReadRepositories;

public class EfReadRepositoryBase<TypeEntity, TypeContext> : EfRepositoryBase<TypeEntity, TypeContext>, IAsyncReadRepository<TypeEntity>, IReadRepository<TypeEntity> where TypeEntity : BaseEntity where TypeContext : DbContext
{
    public EfReadRepositoryBase(TypeContext context) : base(context) { }

    public async Task<TypeEntity?> GetAsync(Expression<Func<TypeEntity, Boolean>> predicate)
    {
        return await Context.Set<TypeEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<IPaginate<TypeEntity>> GetListAsync(
            Expression<Func<TypeEntity, Boolean>>? predicate = null,
            Func<IQueryable<TypeEntity>, IOrderedQueryable<TypeEntity>>? orderBy = null,
            Func<IQueryable<TypeEntity>, IIncludableQueryable<TypeEntity, Object>>? include = null,
            Int32 index = 0, Int32 size = 10,
            Boolean enableTracking = true,
            CancellationToken cancellationToken = default
        )
    {
        IQueryable<TypeEntity> queryable = Query();
        if (enableTracking is false)
            queryable = queryable.AsNoTracking();
        if (include is not null)
            queryable = include(queryable);
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (orderBy is not null)
            return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public async Task<IPaginate<TypeEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                                                                Func<IQueryable<TypeEntity>,
                                                                        IIncludableQueryable<TypeEntity, Object>>?
                                                                    include = null,
                                                                Int32 index = 0, Int32 size = 10,
                                                                Boolean enableTracking = true,
                                                                CancellationToken cancellationToken = default)
    {
        IQueryable<TypeEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (enableTracking is false)
            queryable = queryable.AsNoTracking();
        if (include is not null)
            queryable = include(queryable);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public IQueryable<TypeEntity> Query()
    {
        return Context.Set<TypeEntity>();
    }

    public TypeEntity? Get(Expression<Func<TypeEntity, Boolean>> predicate)
    {
        return Context.Set<TypeEntity>().FirstOrDefault(predicate);
    }

    public IPaginate<TypeEntity> GetList(Expression<Func<TypeEntity, Boolean>>? predicate = null,
                                      Func<IQueryable<TypeEntity>, IOrderedQueryable<TypeEntity>>? orderBy = null,
                                      Func<IQueryable<TypeEntity>, IIncludableQueryable<TypeEntity, Object>>? include = null,
                                      Int32 index = 0, Int32 size = 10,
                                      Boolean enableTracking = true)
    {
        IQueryable<TypeEntity> queryable = Query();
        if (enableTracking is false)
            queryable = queryable.AsNoTracking();
        if (include is not null)
            queryable = include(queryable);
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (orderBy is not null)
            return orderBy(queryable).ToPaginate(index, size);
        return queryable.ToPaginate(index, size);
    }

    public IPaginate<TypeEntity> GetListByDynamic(Dynamic.Dynamic dynamic,
                                               Func<IQueryable<TypeEntity>, IIncludableQueryable<TypeEntity, Object>>?
                                                   include = null, Int32 index = 0, Int32 size = 10,
                                               Boolean enableTracking = true)
    {
        IQueryable<TypeEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (enableTracking is false)
            queryable = queryable.AsNoTracking();
        if (include is not null)
            queryable = include(queryable);
        return queryable.ToPaginate(index, size);
    }

    public async Task<TypeEntity?> GetByIdAsync(Guid id, Boolean enableTracking = true) {
       return enableTracking ? 
            await Context.Set<TypeEntity>().FindAsync(id) :
            await Context.Set<TypeEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }
}
