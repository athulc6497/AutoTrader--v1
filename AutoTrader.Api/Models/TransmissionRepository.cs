using AutoTrader.Models.CarInfo;
using Microsoft.EntityFrameworkCore;

namespace AutoTrader.Api.Models
{
    public class TransmissionRepository : ITransmissionRepository
    {
        private readonly AppDbContext appDbContext;
        public TransmissionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Transmission>> GetTransmissionTypes()
        {
            return await appDbContext.Transmissions.ToListAsync();
        }

        public async Task<Transmission> GetTransmissionType(int Id)
        {
            return await appDbContext.Transmissions.FirstOrDefaultAsync(c => c.TransmissionId == Id);

        }

        public async Task<Transmission> CreateTransmissionType(Transmission transmission)
        {
            var result = await appDbContext.Transmissions.AddAsync(transmission);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transmission> DeleteTransmissionType(int Id)
        {
            var result = await appDbContext.Transmissions.FirstOrDefaultAsync(v => v.TransmissionId == Id);
            if (result != null)
            {
                appDbContext.Transmissions.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Transmission> UpdateTransmissionType(Transmission transmission)
        {
            var result = await appDbContext.Transmissions.FirstOrDefaultAsync(e => e.TransmissionId == transmission.TransmissionId);
            if (result != null)
            {
                result.Name = transmission.Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}