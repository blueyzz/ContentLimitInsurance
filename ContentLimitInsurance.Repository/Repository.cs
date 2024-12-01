namespace ContentLimitInsurance.Repository;

public class Repository : IRepository
{
    protected readonly ContentLimitInsuranceContext Entities;
    public Repository(ContentLimitInsuranceContext entities)
    {
        Entities = entities;
    }

    public IQueryable<T> Load<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        IQueryable<T> query = Entities.Set<T>();
        return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }

    public void Add<T>(T entity) where T : class
    {
        Entities.Set<T>().Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        Entities.Set<T>().Update(entity);
    }

    public void Delete<T>(int id) where T : class
    {
        var entity = Entities.Set<T>().Find(id); 
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity not found");
        Entities.Set<T>().Remove(entity);
    }

    public void Save()
    {
        Entities.SaveChanges();
    }

    public bool Any<T>() where T : class
    {
        return Entities.Set<T>().Any();
    }
}