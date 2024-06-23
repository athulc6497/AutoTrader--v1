using AutoTrader.Models.CarInfo;

namespace AutoTrader.Web.Services
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleType>> GetVehicleTypes();
        Task<VehicleType> GetVehicleType(int id);
        Task<VehicleType> DeleteVehicleType(int id);
        Task<VehicleType> CreateVehicleType(VehicleType vehicleType);
        Task<VehicleType> UpdateVehicleType(VehicleType vehicleType);
    }
}
