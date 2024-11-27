using MilitaryResourcesManagementSystem.API.Models.Domain;

namespace MilitaryResourcesManagementSystem.API.Repositories
{
    public interface IUnitRepository
    {
        Task<List<Unit>> GetAllUnitsAsync();
        Task<List<Unit>> GetAllSoldiersFromUnitAsync(int id);
        Task<Unit> CreateUnitAsync(Unit unit);
    }
}
