using Microsoft.EntityFrameworkCore;
using MilitaryResourcesManagementSystem.API.Data;
using MilitaryResourcesManagementSystem.API.Models.Domain;
using MilitaryResourcesManagementSystem.API.Models.DTO;

namespace MilitaryResourcesManagementSystem.API.Repositories
{
    public class SQLUnitRepository : IUnitRepository
    {
        private readonly MrmsDbContext dbContext;

        public SQLUnitRepository(MrmsDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async Task<Unit> CreateUnitAsync(Unit unit)
        {
            await dbContext.AddAsync(unit);

            await dbContext.SaveChangesAsync();
            
            return unit;
        }

        public async Task<List<Soldier>> GetAllSoldiersFromUnitAsync(int id)
        {
            return await dbContext.Units.Include(u => u.Soldiers).Where(u => u.Id == id).SelectMany(u => u.Soldiers).ToListAsync();
        }

        public async Task<List<Unit>> GetAllUnitsAsync()
        {
            return await dbContext.Units.ToListAsync();
        }
    }
}
