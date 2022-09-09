using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TypeEntity, TypeContext> where TypeEntity : BaseEntity
    where TypeContext : DbContext {
    protected TypeContext Context { get; }

    public EfRepositoryBase(TypeContext context) {
        Context = context;
    }
}