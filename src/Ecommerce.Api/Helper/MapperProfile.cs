using AutoMapper;

namespace Ecommerce.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Create map BETWEEN Entitie User and Model User
            CreateMap<Infrastructure.Entities.User, Core.Models.User>();
            CreateMap<Core.Models.User, Infrastructure.Entities.User>();
            // Create map BETWEEN Entitie Product and Model Product
            CreateMap<Infrastructure.Entities.Product, Core.Models.Product>();
            CreateMap<Core.Models.Product, Infrastructure.Entities.Product>();

            CreateMap<Core.Models.User, Core.Response.UserResponse>();
            CreateMap<Core.Request.UserRequest, Core.Models.User>();
        }
    }
}
