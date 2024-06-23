using AutoTrader.Models.CarInfo;

namespace AutoTrader.Api.Models
{
    public interface IVehicleTypeRepository
    {
        Task<IEnumerable<VehicleType>> GetVehicleTypes();
        Task<VehicleType> GetVehicleType(int Id);
        Task<VehicleType> CreateVehicleType(VehicleType vehicleType);
        Task<VehicleType> DeleteVehicleType(int Id);
        Task<VehicleType> UpdateVehicleType(VehicleType vehicleType);

    }
}
