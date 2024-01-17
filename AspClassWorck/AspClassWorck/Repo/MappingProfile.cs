using AspClassWorck.Models;
using AspClassWorck.Models.DTO;
using AutoMapper;

namespace AspClassWorck.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Group, GroupDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Storage, StoregeDTO>(MemberList.Destination).ReverseMap();
        }
    }
}
