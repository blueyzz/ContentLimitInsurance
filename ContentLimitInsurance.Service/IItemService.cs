namespace ContentLimitInsurance.Service;

public interface IItemService
{
    ICollection<Item> GetItems();
    bool Add(AddItemVM item);
    bool Delete(int itemID);
}