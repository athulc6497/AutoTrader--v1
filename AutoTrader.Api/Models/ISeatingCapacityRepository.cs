using AutoTrader.Models.CarInfo;

namespace AutoTrader.Api.Models
{
    public interface ISeatingCapacityRepository
    {
        Task<IEnumerable<SeatingCapacity>> GetSeatingCapacities();
        Task<SeatingCapacity> GetSeatingCapacity(int carId);
        Task<SeatingCapacity> CreateSeatingCapacity(SeatingCapacity seatingCapacity);
        Task<SeatingCapacity> UpdateSeatingCapacity(SeatingCapacity seatingCapacity);
        Task<SeatingCapacity> DeleteSeatingCapacity(int Id);

    }
}
