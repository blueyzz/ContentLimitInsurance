namespace ContentLimitInsurance.Service;

public class CategoryService : ICategoryService
{
    private readonly IRepository Repository;

    public CategoryService(IRepository repository)
    {
        Repository = repository;
    }


    /// <summary>
    /// Get Categories ordered by name
    /// </summary>
    /// <returns>Collection of categories</returns>
    public virtual ICollection<Category> GetCategories()
    {
        var categories = Repository.Load<Category>().OrderBy(x => x.Name).ToList();
        return categories;
    }
    

    /// <summary>
    /// Get Categories by CategoryID order by name
    /// </summary>
    /// <param name="categoryIDs">Category IDs</param>
    /// <returns>Collection of categories</returns>
    public ICollection<Category> GetCategoriesByCategoryID(List<int> categoryIDs)
    {
        var categories = Repository.Load<Category>().Where(x => categoryIDs.Contains(x.CategoryID)).OrderBy(x => x.Name).ToList();
        return categories;
    }
}