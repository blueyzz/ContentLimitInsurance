namespace ContentLimitInsurance.Service.Models;

public class ItemVM: Item
{
    public string DisplayValue => $"${Value}";
}