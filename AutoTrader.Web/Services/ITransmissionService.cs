using AutoTrader.Models.CarInfo;

namespace AutoTrader.Web.Services
{
    public interface ITransmissionService
    {
        Task<IEnumerable<Transmission>> GetTransmissionTypes();
        Task<Transmission> GetTransmissionType(int id);
        Task<Transmission> DeleteTransmissionType(int id);
        Task<Transmission> CreateTransmissionType(Transmission transmission);
        Task<Transmission> UpdateTransmissionType(Transmission transmission);
    }
}
