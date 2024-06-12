using AutoMapper;
using IdentityWebAPI.Data.Entities;
using IdentityWebAPI.Models.DTO.Owner;

namespace IdentityWebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Owner, OwnerDTO>();
        }
    }
}
