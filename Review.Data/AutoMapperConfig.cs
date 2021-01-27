using AutoMapper;

namespace Review.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.Review, Service.Models.Review>(MemberList.Destination);
        }
    }
}
