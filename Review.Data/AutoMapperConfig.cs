using AutoMapper;

namespace Review.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.Review, Interfaces.Models.Review>(MemberList.Destination);
            CreateMap<Entities.Rating, Interfaces.Models.Rating>(MemberList.Destination);
        }
    }
}
