namespace ContentLimitInsurance.Service;

public interface ICategoryService
{
    ICollection<Category> GetCategories();
    ICollection<Category> GetCategoriesByCategoryID(List<int> categoryIDs);
}