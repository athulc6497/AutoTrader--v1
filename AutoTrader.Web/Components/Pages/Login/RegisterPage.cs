using AutoTrader.Models.Authorization.Registration;
using AutoTrader.Web.Services;
using Microsoft.AspNetCore.Components;

namespace AutoTrader.Web.Components.Pages.Login
{
    public class RegisterPageBase:ComponentBase
    {
        public RegisterUser Register { get; set; } = new RegisterUser();

        [Inject]
        public IRegisterService RegisterService { get; set; }

        protected override Task OnInitializedAsync()
        {

            return base.OnInitializedAsync();
        }

        protected async Task HandleSubmit()
        {
            Register = await RegisterService.Register(Register);
        }
    }
}
