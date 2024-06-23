using AutoTrader.Models.CarInfo;

namespace AutoTrader.Web.Services
{
    public class TransmissionService : ITransmissionService

    {
        private readonly HttpClient httpClient;
        public TransmissionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public async Task<IEnumerable<Transmission>> GetTransmissionTypes()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<Transmission>>("api/transmissions");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                // Re-throw the exception if needed
                throw;
            }
        }

        public async Task<Transmission> GetTransmissionType(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Transmission>($"api/transmissions/{id}");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<Transmission> CreateTransmissionType(Transmission transmission)
        {
            try
            {
                // Send PUT request and wait for the response
                var response = await httpClient.PutAsJsonAsync("api/transmissions", transmission).ConfigureAwait(false);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body to a CarDetails object
                    return await response.Content.ReadFromJsonAsync<Transmission>().ConfigureAwait(false);
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

        public async Task<Transmission> UpdateTransmissionType(Transmission transmission)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync($"api/transmissions/", transmission);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Transmission>();
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
        public async Task<Transmission> DeleteTransmissionType(int Id)
        {
            return await httpClient.GetFromJsonAsync<Transmission>($"api/transmissions/{Id}");
        }
    }
}