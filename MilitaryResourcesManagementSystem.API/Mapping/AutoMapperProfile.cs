using AutoMapper;
using MilitaryResourcesManagementSystem.API.Models.Domain;
using MilitaryResourcesManagementSystem.API.Models.DTO;

namespace MilitaryResourcesManagementSystem.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Soldier, SoldierDTO>()
                .ForMember(x => x.UnitName, opt => opt.MapFrom(x => x.Unit.Name))
                .ReverseMap();
            CreateMap<Soldier, SoldierGetDTO>().ReverseMap();
            CreateMap<Soldier, AddSoldierRequestDto>().ReverseMap();
            CreateMap<Soldier, ChangeSoldierUnitDTO>().ReverseMap();
            CreateMap<Unit, UnitDTO>().ReverseMap();
            CreateMap<Unit, UnitGetDTO>().ReverseMap();
            CreateMap<Unit, AddUnitRequestDto>().ReverseMap();

        }
    }
}
