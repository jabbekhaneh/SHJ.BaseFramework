using AutoMapper;

namespace SHJ.BaseFramework.Shared.CustomMappings;

public interface IHaveCustomMapping
{
    void CreateMappings(Profile profile);
}