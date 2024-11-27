using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryResourcesManagementSystem.API.Models.Domain;
using MilitaryResourcesManagementSystem.API.Models.DTO;
using MilitaryResourcesManagementSystem.API.Repositories;

namespace MilitaryResourcesManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IMapper unitMapper;
        private readonly IUnitRepository unitRepository;

        public UnitsController(IMapper unitMapper,IUnitRepository unitRepository)
        {
            this.unitMapper=unitMapper;
            this.unitRepository=unitRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnit([FromBody] AddUnitRequestDto addUnitRequest)
        {
            var unitDomainModel = unitMapper.Map<Unit>(addUnitRequest);

            unitDomainModel = await unitRepository.CreateUnitAsync(unitDomainModel);

            return Ok(unitMapper.Map<Unit>(unitDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUnits()
        {
            var unitsDomainModel = await unitRepository.GetAllUnitsAsync();

            return Ok(unitMapper.Map<List<UnitDTO>>(unitsDomainModel));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAllUnitSoldiers([FromRoute] int id)
        {
            var unitDomainModel = await unitRepository.GetAllSoldiersFromUnitAsync(id);

            if (unitDomainModel == null)
            {
                return NotFound();
            }

            return Ok(unitMapper.Map<List<UnitDTO>>(unitDomainModel));
        }
    }
}
