namespace Linter.IRepositories;

public interface IGenericRepository<T> where T : class
{
    public  Task Create(T entity);
    public  Task Update(T entity);
    public  Task Delete(T entity);
    public  Task<T> Get(Guid id);
    public  Task<IEnumerable<T>> GetAll(Func<T, bool> filter);
}