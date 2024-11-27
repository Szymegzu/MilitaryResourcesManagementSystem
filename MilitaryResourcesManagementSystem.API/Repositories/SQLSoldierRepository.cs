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
        public async Task<Soldier> CreateSoldierAsync(Soldier soldier)
        {
            await dbContext.Soldiers.AddAsync(soldier);

            await dbContext.SaveChangesAsync();

            return soldier;
        }

        public async Task<List<Soldier>> GetAllSoldiersAsync()
        {
            return await dbContext.Soldiers.Include("Unit").ToListAsync();
        }

        public Task<Soldier?> GetSoldierByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
