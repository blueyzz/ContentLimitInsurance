namespace ContentLimitInsurance.Repository;

public interface IRepository
{
    IQueryable<T> Load<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(int id, CancellationToken cancellationToken = default) where T : class;
    bool Any<T>() where T : class;
    void Save(CancellationToken cancellationToken = default);
}