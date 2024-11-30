namespace ContentLimitInsurance.Core;

public class DBInitializer : IDBInitializer
{
    public void Initialize(ContentLimitInsuranceContext context)
    {
        context.Database.EnsureCreated();

        //Check if database has been seeded
        if (context.Categories.Any()) return;

        var categories = new List<Category>
        {
            new("Electronics"),
            new("Clothing"),
            new("Kitchen")
        };

        foreach (var category in categories)
        {
            context.Categories.Add(category);
        }
        context.SaveChanges();
    }
}