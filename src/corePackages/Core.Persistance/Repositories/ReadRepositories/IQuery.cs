namespace Core.Persistence.Repositories.ReadRepositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}