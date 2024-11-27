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
        [HttpPost]
        public async Task<IActionResult> CreateSoldier([FromBody] AddSoldierRequestDto addSoldier)
        {
            var soldierDomainModel = soldierMapper.Map<Soldier>(addSoldier);

            soldierDomainModel = await soldierRepository.CreateSoldierAsync(soldierDomainModel);

            return Ok(soldierMapper.Map<SoldierDTO>(soldierDomainModel));
        }
        
    }
}
