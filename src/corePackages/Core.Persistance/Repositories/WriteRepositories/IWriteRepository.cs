namespace Core.Persistence.Repositories.WriteRepositories;

public interface IWriteRepository<TypeEntity> : IAsyncWriteRepository<TypeEntity> where TypeEntity : BaseEntity {
    TypeEntity Add(TypeEntity entity);
    TypeEntity Update(TypeEntity entity);
    TypeEntity Delete(TypeEntity entity);
}