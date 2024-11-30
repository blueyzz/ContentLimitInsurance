namespace ContentLimitInsurance.Server.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddItemVM, Item>();
        CreateMap<Item, ItemVM>();
        CreateMap<Category, CategoryVM>();
    }
}