using AutoTrader.Models.CarInfo;
using AutoTrader.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AutoTrader.Web.Components.Pages
{
    public class CreateCarBase:ComponentBase
    {

        public CarDetails CarDetails { get; set; } = new CarDetails();

        [Inject]
        public ICarListService CarListService { get; set; }

        [Inject]
        public IVehicleTypeService VehicleTypeService { get; set; }

        [Inject]
        public ITransmissionService TransmissionService { get; set; }
        [Inject]
        public ISeatingCapacityService SeatingCapacityService { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<VehicleType> VehicleTypes { get; set; } = new List<VehicleType>();

        public List<Transmission> Transmission { get; set; } = new List<Transmission>();
        public List<SeatingCapacity> SeatingCapacities { get; set; } = new List<SeatingCapacity>();

        [Parameter]
        public int? Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            VehicleTypes = (await VehicleTypeService.GetVehicleTypes()).ToList();
            Transmission = (await TransmissionService.GetTransmissionTypes()).ToList();
            SeatingCapacities = (await SeatingCapacityService.GetSeatingCapacities()).ToList();

            if (Id.HasValue && Id.Value != 0)
            {
                CarDetails = await CarListService.GetCar(Id.Value);
            }
            else
            {
                CarDetails = new CarDetails
                {
                    VehicleTypeId = VehicleTypes.FirstOrDefault()?.VehicleTypeId ?? 1,
                    TransmissionId = Transmission.FirstOrDefault()?.TransmissionId ?? 1,
                    SeatingCapacityId = SeatingCapacities.FirstOrDefault()?.SeatingCapacityId ?? 1,
                    DriveId = SeatingCapacities.FirstOrDefault()?.SeatingCapacityId ?? 1,
                    FuelId = 1

                };
            }
        }

        public async Task LoadFiles(InputFileChangeEventArgs e)
        {

            if (e.File != null)
            {
                var buffer = new byte[e.File.Size];
                await e.File.OpenReadStream().ReadAsync(buffer);
                CarDetails.Photo = buffer;
            }
            else
                CarDetails.Photo = null;

        }
        protected async Task HandleSubmit()
        {


            if (CarDetails.CarId != 0)
            {
                CarDetails = await CarListService.UpdateCar(CarDetails);
            }
            else
            {

                CarDetails = await CarListService.CreateCar(CarDetails);
            }

            if (CarDetails == null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
