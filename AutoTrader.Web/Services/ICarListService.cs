using AutoTrader.Models.CarInfo;

namespace AutoTrader.Web.Services
{
    public interface ICarListService
    {
        Task<IEnumerable<CarDetails>> GetCars();
        Task<CarDetails> GetCar(int Id);
        Task<CarDetails> DeleteCar(int Id);

        Task<CarDetails> CreateCar(CarDetails newcarDetails);
        Task<CarDetails> UpdateCar(CarDetails updatecarDetails);
    }
}
