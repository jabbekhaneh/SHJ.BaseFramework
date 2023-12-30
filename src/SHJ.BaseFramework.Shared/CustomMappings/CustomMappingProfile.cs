using AutoMapper;

namespace SHJ.BaseFramework.Shared.CustomMappings;

public class CustomMappingProfile : Profile
{
    public CustomMappingProfile(IEnumerable<IHaveCustomMapping> haveCustomMappings)
    {
        foreach (var item in haveCustomMappings)
            item.CreateMappings(this);
    }
}