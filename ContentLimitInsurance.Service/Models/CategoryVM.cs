namespace ContentLimitInsurance.Service.Models;

public class CategoryVM : Category
{
    public ICollection<ItemVM> Items { get; set; }

    public int CategoryTotal => Items.Sum(item => item.Value);

    public string DisplayCategoryTotal => $"${CategoryTotal}";

    public CategoryVM(string name) : base(name)
    {
        Name = name;
    }
}