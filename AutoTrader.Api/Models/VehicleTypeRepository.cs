using AutoTrader.Models.CarInfo;
using Microsoft.EntityFrameworkCore;

namespace AutoTrader.Api.Models
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly AppDbContext appDbContext;
        public VehicleTypeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;


        }


        public async Task<IEnumerable<VehicleType>> GetVehicleTypes()
        {
            return await appDbContext.VehicleTypes.ToListAsync();
        }

        public async Task<VehicleType> GetVehicleType(int Id)
        {
            return await appDbContext.VehicleTypes.FirstOrDefaultAsync(c => c.VehicleTypeId == Id);

        }

        public async Task<VehicleType> CreateVehicleType(VehicleType vehicleType)
        {
            var result = await appDbContext.VehicleTypes.AddAsync(vehicleType);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VehicleType> DeleteVehicleType(int Id)
        {
            var result = await appDbContext.VehicleTypes.FirstOrDefaultAsync(v => v.VehicleTypeId == Id);
            if (result != null)
            {
                appDbContext.VehicleTypes.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<VehicleType> UpdateVehicleType(VehicleType vehicleType)
        {
            var result = await appDbContext.VehicleTypes.FirstOrDefaultAsync(e => e.VehicleTypeId == vehicleType.VehicleTypeId);
            if (result != null)
            {
                result.Name = vehicleType.Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
