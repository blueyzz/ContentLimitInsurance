namespace ContentLimitInsurance.Repositories;

public class Repository<T> : IRepository<T> where T : class
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

    public async Task Add(T entity)
    {
        await Entities.Set<T>().AddAsync(entity);
    }

    public async Task Update(T entity)
    {
        Entities.Set<T>().Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await Entities.Set<T>().FindAsync(id);
        Entities.Set<T>().Remove(entity);
    }

    public async Task Save()
    {
        await Entities.SaveChangesAsync();
    }
}
