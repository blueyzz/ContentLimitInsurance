namespace ContentLimitInsurance.Repositories;

public interface IRepository<T> where T : class
{
    public IQueryable<T> Load<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
    Task Save();
}