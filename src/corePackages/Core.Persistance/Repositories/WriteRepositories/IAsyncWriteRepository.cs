using Core.Persistence.Repositories;

namespace Core.Persistence.Repositories.WriteRepositories;

public interface IAsyncWriteRepository<TypeEntity> where TypeEntity : BaseEntity {
    Task<TypeEntity> AddAsync(TypeEntity entity);
    Task<TypeEntity> UpdateAsync(TypeEntity entity);
    Task<TypeEntity> DeleteAsync(TypeEntity entity);
}