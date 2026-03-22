using AutoMapper;
using Home360.Application.DTOs;
using Home360.Domain.Entities;

namespace Home360.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region 
            // User Management Mappings
            CreateMap<UserRquest, User>();
            CreateMap<User, UserResponse>().ReverseMap();
            #endregion
        }
    }
}
