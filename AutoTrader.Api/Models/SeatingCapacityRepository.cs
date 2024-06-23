using AutoTrader.Models.CarInfo;
using Microsoft.EntityFrameworkCore;

namespace AutoTrader.Api.Models
{
    public class SeatingCapacityRepository : ISeatingCapacityRepository
    {
        private readonly AppDbContext appDbContext;

        public SeatingCapacityRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<IEnumerable<SeatingCapacity>> GetSeatingCapacities()
        {
            return await appDbContext.SeatingCapacities.ToListAsync();
        }
        public async Task<SeatingCapacity> GetSeatingCapacity(int Id)
        {
            return await appDbContext.SeatingCapacities.FirstOrDefaultAsync(c => c.SeatingCapacityId == Id);
        }
        public async Task<SeatingCapacity> CreateSeatingCapacity(SeatingCapacity seatingCapacity)
        {
            var result = await appDbContext.SeatingCapacities.AddAsync(seatingCapacity);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<SeatingCapacity> DeleteSeatingCapacity(int Id)
        {
            var result = await appDbContext.SeatingCapacities.FirstOrDefaultAsync(c => c.SeatingCapacityId == Id);
            if (result != null)
            {
                appDbContext.SeatingCapacities.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<SeatingCapacity> UpdateSeatingCapacity(SeatingCapacity seatingCapacity)
        {
            var result = await appDbContext.SeatingCapacities.FirstOrDefaultAsync(e => e.SeatingCapacityId == seatingCapacity.SeatingCapacityId);
            if (result != null)
            {
                result.Description = seatingCapacity.Description;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


    }
}
