using AutoTrader.Models.CarInfo;

namespace AutoTrader.Web.Services
{
    public class CarListService : ICarListService
    {

        private readonly HttpClient httpClient;
        public CarListService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<CarDetails>> GetCars()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<CarDetails>>("api/cars");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                // Re-throw the exception if needed
                throw;
            }
        }
        public async Task<CarDetails> GetCar(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<CarDetails>($"api/cars/{id}");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<CarDetails> CreateCar(CarDetails newcarDetails)
        {
            try
            {
                // Send PUT request and wait for the response
                var response = await httpClient.PostAsJsonAsync("api/cars", newcarDetails).ConfigureAwait(false);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body to a CarDetails object
                    return await response.Content.ReadFromJsonAsync<CarDetails>().ConfigureAwait(false);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorMessage = $"Failed to create car. Status code: {response.StatusCode}. Response: {errorContent}";

                    // Handle the error response
                    throw new HttpRequestException(errorMessage);
                }
            }
            catch (Exception)
            {
                // Handle any exceptions
                throw;
            }
        }

        public async Task<CarDetails> UpdateCar(CarDetails updatecarDetails)
        {
            try
            {
                // Send PUT request and wait for the response
                var response = await httpClient.PutAsJsonAsync("api/cars/", updatecarDetails).ConfigureAwait(false);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body to a CarDetails object
                    return await response.Content.ReadFromJsonAsync<CarDetails>().ConfigureAwait(false);
                }
                else
                {
                    // Handle the error response
                    // You might want to throw an exception or handle it differently based on your requirements
                    throw new Exception($"Failed to create car. Status code: {response.StatusCode}");
                }
            }
            catch (Exception)
            {
                // Handle any exceptions
                throw;
            }
        }

        public async Task<CarDetails> DeleteCar(int Id)
        {
            return await httpClient.GetFromJsonAsync<CarDetails>($"api/cars/{Id}");
        }
    }
}