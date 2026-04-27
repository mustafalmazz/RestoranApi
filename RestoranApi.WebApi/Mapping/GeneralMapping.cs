using AutoMapper;
using RestoranApi.WebApi.Dtos.FeatureDtos;
using RestoranApi.WebApi.Dtos.MessageDtos;
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

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessage>().ReverseMap();
        }
    }
}
