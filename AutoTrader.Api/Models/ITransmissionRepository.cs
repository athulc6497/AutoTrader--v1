using AutoTrader.Models.CarInfo;

namespace AutoTrader.Api.Models
{
    public interface ITransmissionRepository
    {
        Task<IEnumerable<Transmission>> GetTransmissionTypes();
        Task<Transmission> GetTransmissionType(int Id);
        Task<Transmission> CreateTransmissionType(Transmission transmission);
        Task<Transmission> DeleteTransmissionType(int Id);
        Task<Transmission> UpdateTransmissionType(Transmission transmission);
    }
}
