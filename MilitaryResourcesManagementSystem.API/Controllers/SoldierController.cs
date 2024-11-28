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
    public class SoldierController : ControllerBase
    {
        private readonly ISoldierRepository soldierRepository;
        private readonly IMapper soldierMapper;

        public SoldierController(ISoldierRepository soldierRepository,IMapper soldierMapper)
        {
            this.soldierRepository=soldierRepository;
            this.soldierMapper=soldierMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSoldiers()
        {
            var soldierDomain = await soldierRepository.GetAllSoldiersAsync();

            return Ok(soldierMapper.Map<List<SoldierDTO>>(soldierDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetSoldierById([FromRoute] Guid id)
        {
            var soldierDomainModel = await soldierRepository.GetSoldierByIdAsync(id);

            if (soldierDomainModel == null)
            {
                return NotFound();
            }

            return Ok(soldierMapper.Map<SoldierDTO>(soldierDomainModel));

        }

        [HttpPost]
        public async Task<IActionResult> CreateSoldier([FromBody] AddSoldierRequestDto addSoldier)
        {
            var soldierDomainModel = soldierMapper.Map<Soldier>(addSoldier);

            soldierDomainModel = await soldierRepository.CreateSoldierAsync(soldierDomainModel);

            return Ok(soldierMapper.Map<SoldierDTO>(soldierDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> ChangeSoldierUnit([FromBody] ChangeSoldierUnitDTO changeSoldierUnit, [FromRoute] Guid id)
        {
            var soldierDomainModel = soldierMapper.Map<Soldier>(changeSoldierUnit);

            soldierDomainModel = await soldierRepository.ChangeSoldierUnitAsync(soldierDomainModel, id);

            if (soldierDomainModel == null)
            {
                return NotFound();
            }

            return Ok(soldierMapper.Map<SoldierGetDTO>(soldierDomainModel));
        }


    }
}
