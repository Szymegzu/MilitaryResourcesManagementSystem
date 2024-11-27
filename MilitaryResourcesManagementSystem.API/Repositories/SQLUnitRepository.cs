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

        public async Task<List<Unit>> GetAllSoldiersFromUnitAsync(int id)
        {
            var checkId = await dbContext.Units.FirstOrDefaultAsync(x => x.Id == id);

            if (checkId == null)
            {
                return null;
            }

            return await dbContext.Units.Where(x => x.Id == id)..ToListAsync();
        }

        public async Task<List<Unit>> GetAllUnitsAsync()
        {
            return await dbContext.Units.ToListAsync();
        }
    }
}
