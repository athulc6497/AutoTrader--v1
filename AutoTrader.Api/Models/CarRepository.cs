using AutoTrader.Models.CarInfo;
using Microsoft.EntityFrameworkCore;

namespace AutoTrader.Api.Models
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<IEnumerable<CarDetails>> GetCars()
        {
            return await appDbContext.Cars.ToListAsync();
        }
        public async Task<CarDetails> GetCar(int Id)
        {
            return await appDbContext.Cars.FirstOrDefaultAsync(c => c.CarId == Id);
        }
        public async Task<CarDetails> AddCar(CarDetails carDetails)
        {
            var result = await appDbContext.Cars.AddAsync(carDetails);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CarDetails> DeleteCar(int carId)
        {
            var result = await appDbContext.Cars.FirstOrDefaultAsync(c => c.CarId == carId);
            if (result != null)
            {
                appDbContext.Cars.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<CarDetails> UpdateCar(CarDetails carDetails)
        {
            var result = await appDbContext.Cars.FirstOrDefaultAsync(e => e.CarId == carDetails.CarId);
            if (result != null)
            {
                result.VehicleTypeId = carDetails.VehicleTypeId;
                result.Engine = carDetails.Engine;
                result.TransmissionId = carDetails.TransmissionId;
                result.Ownership = carDetails.Ownership;
                result.PeakTorque = carDetails.PeakTorque;
                result.ModelName = carDetails.ModelName;
                result.Doors = carDetails.Doors;
                result.DriveId = carDetails.DriveId;
                result.SeatingCapacityId = carDetails.SeatingCapacityId;
                result.ManufacturingYear = carDetails.ManufacturingYear;
                result.FuelId = carDetails.FuelId;
                result.KmsDone = carDetails.KmsDone;
                result.Price = carDetails.Price;
                result.ExteriorColor = carDetails.ExteriorColor;
                result.PaidFeature = carDetails.PaidFeature;
                result.Photo = carDetails.Photo;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


    }
}