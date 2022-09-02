using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories.WriteRepositories;

public class EfWriteRepositoryBase<TypeEntity, TypeContext> : EfRepositoryBase<TypeEntity, TypeContext>, /*IAsyncWriteRepository<TypeEntity>,*/ IWriteRepository<TypeEntity> where TypeEntity : BaseEntity where TypeContext : DbContext
{
    public EfWriteRepositoryBase(TypeContext context) : base(context) { }

    public async Task<TypeEntity> AddAsync(TypeEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TypeEntity> UpdateAsync(TypeEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TypeEntity> DeleteAsync(TypeEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return entity;
    }

    public TypeEntity Add(TypeEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public TypeEntity Update(TypeEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }

    public TypeEntity Delete(TypeEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        Context.SaveChanges();
        return entity;
    }
}