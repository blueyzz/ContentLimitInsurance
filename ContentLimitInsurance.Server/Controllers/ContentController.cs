namespace ContentLimitInsurance.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ContentController : ControllerBase
{
    private readonly IContentService ContentService;
    private readonly ICategoryService CategoryService;
    private readonly IItemService ItemService;

    public ContentController(IContentService contentService, ICategoryService categoryService, IItemService itemService)
    {
        ContentService = contentService;
        CategoryService = categoryService;
        ItemService = itemService;
    }

    [HttpGet]
    [Route("[action]")]
    public virtual JsonResult GetContent()
    {
        try
        {
            //Get ContentVM Data
            var content = ContentService.GetData();
            return new JsonResult(content, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpGet]
    [Route("[action]")]
    public virtual JsonResult GetCategories()
    {
        try
        {
            var categories = CategoryService.GetCategories();
            return new JsonResult(categories, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpPost("[action]")]
    public virtual JsonResult AddItem(AddItemVM itemVM)
    {
        try
        {
            var added  = ItemService.Add(itemVM);
            return new JsonResult(added, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpPost("[action]")]
    public virtual JsonResult DeleteItem(DeleteItemRequestVM request)
    {
        try
        {
            var deleted = ItemService.Delete(request.ItemID);
            return new JsonResult(deleted, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}