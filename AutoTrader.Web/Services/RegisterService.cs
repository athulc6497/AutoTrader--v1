using AutoTrader.Models.Authorization.Login;
using AutoTrader.Models.Authorization.Registration;

namespace AutoTrader.Web.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly HttpClient httpClient;
        public RegisterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

        }

     
        public async Task<RegisterUser> Register(RegisterUser user)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/Authentication", user).ConfigureAwait(false);
                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RegisterUser>().ConfigureAwait(false);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorMessage = $"Failed to create car. Status code: {response.StatusCode}. Response: {errorContent}";

                    throw new HttpRequestException(errorMessage);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LoginResponse> Login(LoginModel user)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/Authentication/login", user).ConfigureAwait(false);
                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<LoginResponse>().ConfigureAwait(false);
                }
                else
                {
                    throw new HttpRequestException($"Login failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
