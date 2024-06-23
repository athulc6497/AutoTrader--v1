using AutoTrader.Models.CarInfo;

namespace AutoTrader.Web.Services
{
    public interface ISeatingCapacityService
    {
        Task<IEnumerable<SeatingCapacity>> GetSeatingCapacities();
        Task<SeatingCapacity> GetSeatingCapacity(int id);
        Task<SeatingCapacity> DeleteSeatingCapacity(int id);
        Task<SeatingCapacity> CreateSeatingCapacity(SeatingCapacity seatingCapacity);
        Task<SeatingCapacity> UpdateSeatingCapacity(SeatingCapacity seatingCapacity);
    }
}
