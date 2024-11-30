namespace ContentLimitInsurance.Core.Entities;

public class Item
{
    /// <summary>
    /// Item ID
    /// </summary>
    public int ItemID { get; set; }


    /// <summary>
    /// Item Name
    /// </summary>
    public string Name { get; set; }
    

    /// <summary>
    /// Item Value
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Item Category
    /// </summary>
    public int CategoryID { get; set; }
    public virtual Category Category { get; set; }
}