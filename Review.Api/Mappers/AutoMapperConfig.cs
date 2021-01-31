using AutoMapper;

namespace Review.Api.Mappers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Service.Models.Review, Models.Review>(MemberList.Destination).ReverseMap();
        }
    }
}
