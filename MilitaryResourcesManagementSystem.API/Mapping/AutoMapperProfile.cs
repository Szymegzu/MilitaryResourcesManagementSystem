using AutoMapper;
using MilitaryResourcesManagementSystem.API.Models.Domain;
using MilitaryResourcesManagementSystem.API.Models.DTO;

namespace MilitaryResourcesManagementSystem.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Soldier, SoldierDTO>().ReverseMap();
            CreateMap<Soldier, AddSoldierRequestDto>().ReverseMap();
            CreateMap<Unit, UnitDTO>().ReverseMap();
            CreateMap<Unit, AddUnitRequestDto>().ReverseMap();

        }
    }
}
