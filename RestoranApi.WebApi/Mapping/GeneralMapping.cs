using AutoMapper;
using RestoranApi.WebApi.Dtos.FeatureDtos;
using RestoranApi.WebApi.Entities;

namespace RestoranApi.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
            CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature,GetByIdFeature>().ReverseMap();
        }
    }
}
