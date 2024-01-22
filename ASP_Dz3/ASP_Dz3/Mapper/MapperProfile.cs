using AutoMapper;
using ASP_Dz3.Models;
using ASP_Dz3.Models.Dto;

namespace ASP_Dz3.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<StorageEntity, StorageDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
        }
    }
}
