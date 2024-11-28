using Microsoft.EntityFrameworkCore;
using MilitaryResourcesManagementSystem.API.Data;
using MilitaryResourcesManagementSystem.API.Models.Domain;

namespace MilitaryResourcesManagementSystem.API.Repositories
{
    public class SQLSoldierRepository : ISoldierRepository
    {
        private readonly MrmsDbContext dbContext;

        public SQLSoldierRepository(MrmsDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<Soldier> ChangeSoldierUnitAsync(Soldier soldier, Guid id)
        {
            var existingSoldier = await dbContext.Soldiers.Include(s => s.Unit).FirstOrDefaultAsync(x => x.Id == id);

            if (existingSoldier == null)
            {
                return null;
            }

            existingSoldier.UnitId = soldier.UnitId;

            await dbContext.SaveChangesAsync();

            return existingSoldier;

        }

        public async Task<Soldier> CreateSoldierAsync(Soldier soldier)
        {
            await dbContext.Soldiers.AddAsync(soldier);

            await dbContext.SaveChangesAsync();

            return soldier;
        }

        public async Task<List<Soldier>> GetAllSoldiersAsync()
        {

            return await dbContext.Soldiers.Include(s => s.Unit).ToListAsync();
        }

        public async Task<Soldier?> GetSoldierByIdAsync(Guid id)
        {
            return await dbContext.Soldiers.Include(s => s.Unit).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
