namespace ContentLimitInsurance.Service;

public class ContentService : IContentService
{
    private readonly IMapper Mapper;
    private readonly IItemService ItemService;
    private readonly ICategoryService CategoryService;

    public ContentService(IMapper mapper, IItemService itemService, ICategoryService categoryService)
    {
        Mapper = mapper;
        ItemService = itemService;
        CategoryService = categoryService;
    }


    /// <summary>
    /// Get ContentVM
    /// Items with their Categories
    /// </summary>
    /// <returns>List of Categories with their items</returns>
    public virtual ContentVM GetData()
    {
        //Get items
        var loadItems = ItemService.GetItems();
        var items = Mapper.Map<List<ItemVM>>(loadItems);
        
        //Get Category IDs
        var categoryIDs = loadItems.Select(x => x.CategoryID).ToList();
        
        //Get Categories
        var loadCategories = CategoryService.GetCategoriesByCategoryID(categoryIDs);
        var categories = Mapper.Map<List<CategoryVM>>(loadCategories);
        
        //Attach items by category
        foreach (var category in categories)
        {
            category.Items = items.Where(x => x.CategoryID == category.CategoryID).ToList();
        }
        
        var content = new ContentVM
        {
            Categories = categories
        };

        return content;
    }
}