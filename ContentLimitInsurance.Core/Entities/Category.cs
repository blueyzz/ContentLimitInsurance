namespace ContentLimitInsurance.Core.Entities;

public class Category
{
    public Category()
    {
    }

    /// <summary>
    /// Category ID
    /// </summary>
    [Key]
    public int CategoryID { get; set; }
    
    /// <summary>
    /// Category Name
    /// </summary>
    public string Name { get; set; }

    public virtual ICollection<Item> Items { get; set; }

    
    public Category(string name)
    {
        Name = name;
    }
}