namespace ContentLimitInsurance.Specs.MockData;

public static class CategoryMockData
{
    public static List<Category> GetTestCategories()
    {
        var categories = new List<Category>
        {
            new() { CategoryID = 1, Name = "Electronics" },
            new() { CategoryID = 2, Name = "Kitchen" },
            new() { CategoryID = 3, Name = "Clothing" }
        };
        return categories;
    }
}