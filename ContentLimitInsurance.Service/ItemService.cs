namespace ContentLimitInsurance.Service;

public class ItemService : IItemService
{
    private readonly IRepository Repository;
    private readonly IMapper Mapper;
    
    public ItemService(IRepository repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }


    /// <summary>
    /// Get Items
    /// </summary>
    /// <returns>Items</returns>
    public virtual ICollection<Item> GetItems()
    {
        return Repository.Load<Item>().OrderBy(x => x.Name).ToList();
    }


    /// <summary>
    /// Add Item
    /// </summary>
    /// <param name="itemVM"></param>
    /// <returns></returns>
    public virtual bool Add(AddItemVM itemVM)
    {
        var item = Mapper.Map<Item>(itemVM);
        Repository.Add(item);
        Repository.Save();
        return true;
    }


    /// <summary>
    /// Delete Item by Item ID
    /// </summary>
    /// <param name="itemID">ItemID</param>
    /// <returns></returns>
    public virtual bool Delete(int itemID)
    {
        Repository.Delete<Item>(itemID);
        Repository.Save();
        return true;
    }
}