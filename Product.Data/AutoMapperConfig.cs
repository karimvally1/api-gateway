using AutoMapper;

namespace Product.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.Product, Service.Models.Product>(MemberList.Destination);
            CreateMap<Entities.Category, Service.Models.Category>(MemberList.Destination);
        }
    }
}
