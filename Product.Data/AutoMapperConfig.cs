using AutoMapper;

namespace Product.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.Product, Interfaces.Models.Product>(MemberList.Destination);
        }
    }
}
