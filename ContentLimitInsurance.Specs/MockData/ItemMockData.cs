namespace ContentLimitInsurance.Specs.MockData;
public static class ItemMockData
{
    public static List<Item> GetTestItems()
    {
        var items = new List<Item>
        {
            new () { ItemID = 1, Name = "Monitor", CategoryID = 1, Value = 500 },
            new () { ItemID = 2, Name = "Spoon", CategoryID = 2, Value = 200 },
            new () { ItemID = 3, Name = "Pants", CategoryID = 3, Value = 300 }
        };
        return items;
    }

    public static AddItemVM GetAddItemVM()
    {
        var addItem = new AddItemVM
        {
            Name = "PC",
            CategoryID = 1,
            Value = 1500
        };

        return addItem;
    }

    public static Item GetAddItem()
    {
        var item = new Item
        {
            Name = "PC",
            CategoryID = 1,
            Value = 1500
        };

        return item;
    }
}