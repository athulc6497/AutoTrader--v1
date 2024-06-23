using AutoTrader.Models.CarInfo;

namespace AutoTrader.Web.Services
{
    public class SeatingCapacityService : ISeatingCapacityService

    {
        private readonly HttpClient httpClient;
        public SeatingCapacityService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public async Task<IEnumerable<SeatingCapacity>> GetSeatingCapacities()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<SeatingCapacity>>("api/seatingcapacities");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                // Re-throw the exception if needed
                throw;
            }
        }

        public async Task<SeatingCapacity> GetSeatingCapacity(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<SeatingCapacity>($"api/seatingcapacities/{id}");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<SeatingCapacity> CreateSeatingCapacity(SeatingCapacity seatingCapacity)
        {
            try
            {
                // Send PUT request and wait for the response
                var response = await httpClient.PutAsJsonAsync("api/seatingcapacities", seatingCapacity).ConfigureAwait(false);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body to a CarDetails object
                    return await response.Content.ReadFromJsonAsync<SeatingCapacity>().ConfigureAwait(false);
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

                throw;
            }
        }

        public async Task<SeatingCapacity> UpdateSeatingCapacity(SeatingCapacity seatingCapacity)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync($"api/seatingcapacities/", seatingCapacity);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<SeatingCapacity>();
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error updating employee: {response.ReasonPhrase}, {errorMessage}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SeatingCapacity> DeleteSeatingCapacity(int Id)
        {
            return await httpClient.GetFromJsonAsync<SeatingCapacity>($"api/seatingcapacities/{Id}");
        }
    }
}