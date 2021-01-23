using AutoMapper;

namespace Product.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.Product, Interfaces.Models.Product>(MemberList.Destination);
            CreateMap<Entities.Category, Interfaces.Models.Category>(MemberList.Destination);
        }
    }
}
