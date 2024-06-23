using AutoTrader.Models.Authorization.Login;
using AutoTrader.Models.Authorization.Registration;

namespace AutoTrader.Web.Services
{
    public interface IRegisterService
    {
        Task<RegisterUser> Register(RegisterUser user);
        Task<LoginResponse> Login(LoginModel user);

    }
}
