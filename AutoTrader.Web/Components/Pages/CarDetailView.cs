using AutoTrader.Models.CarInfo;
using AutoTrader.Web.Services;
using Microsoft.AspNetCore.Components;

namespace Cars.Web.Components.Pages
{
    public class CarDetailViewBase:ComponentBase
    {
        public CarDetails CarInformation { get; set; }=new CarDetails();

        [Inject]
        public ICarListService CarListService { get; set; }

        [Parameter]
        public string Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
           CarInformation= await CarListService.GetCar(int.Parse(Id));
        }
    }
}
