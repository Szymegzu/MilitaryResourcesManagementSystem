using MilitaryResourcesManagementSystem.API.Models.Domain;

namespace MilitaryResourcesManagementSystem.API.Repositories
{
    public interface ISoldierRepository
    {
        Task<Soldier?> GetSoldierByIdAsync(Guid id);
        Task<Soldier> CreateSoldierAsync(Soldier soldier);
        Task<List<Soldier>> GetAllSoldiersAsync();

    }
}
