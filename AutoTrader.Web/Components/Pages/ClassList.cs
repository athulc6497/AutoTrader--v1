using AutoTrader.Models.CarInfo;
using AutoTrader.Web.Services;
using Microsoft.AspNetCore.Components;

namespace AutoTrader.Web.Components.Pages
{
    public class CarListBase : ComponentBase
    {

        [Inject]
        public ICarListService CarListService { get; set; }
        public IEnumerable<CarDetails> Cars { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Cars = await CarListService.GetCars();
        }
    }
}
