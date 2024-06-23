using AutoTrader.Models.CarInfo;

namespace AutoTrader.Web.Services
{
    public class VehicleTypeService : IVehicleTypeService

    {
        private readonly HttpClient httpClient;
        public VehicleTypeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public async Task<IEnumerable<VehicleType>> GetVehicleTypes()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<VehicleType>>("api/vehicletypes");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                // Re-throw the exception if needed
                throw;
            }
        }

        public async Task<VehicleType> GetVehicleType(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<VehicleType>($"api/vehicletypes/{id}");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<VehicleType> CreateVehicleType(VehicleType vehicleType)
        {
            try
            {
                // Send PUT request and wait for the response
                var response = await httpClient.PutAsJsonAsync("api/vehicletypes", vehicleType).ConfigureAwait(false);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body to a CarDetails object
                    return await response.Content.ReadFromJsonAsync<VehicleType>().ConfigureAwait(false);
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

        public async Task<VehicleType> UpdateVehicleType(VehicleType vehicleType)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync($"api/vehicleTypes/", vehicleType);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<VehicleType>();
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

        public async Task<VehicleType> DeleteVehicleType(int Id)
        {
            return await httpClient.GetFromJsonAsync<VehicleType>($"api/vehicleTypes/{Id}");
        }
    }
}