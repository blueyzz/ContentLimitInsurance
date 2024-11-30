namespace ContentLimitInsurance.Service.Models;

public class ContentVM
{
    public ICollection<CategoryVM> Categories { get; set; }

    public int Total => Categories.Sum(x => x.CategoryTotal);

    public string DisplayTotal => $"${Total}";
}