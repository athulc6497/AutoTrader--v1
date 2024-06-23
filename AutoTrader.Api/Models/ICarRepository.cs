using AutoTrader.Models.CarInfo;

namespace AutoTrader.Api.Models
{
    public interface ICarRepository
    {
        Task<IEnumerable<CarDetails>> GetCars();
        Task<CarDetails> GetCar(int carId);
        Task<CarDetails> AddCar(CarDetails car);
        Task<CarDetails> UpdateCar(CarDetails car);
        Task<CarDetails> DeleteCar(int Id);
    }
}
