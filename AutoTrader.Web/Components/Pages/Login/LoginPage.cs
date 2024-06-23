using AutoTrader.Models.Authorization.Login;
using AutoTrader.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Win32;

namespace AutoTrader.Web.Components.Pages.Login
{
    public class LoginPageBase:ComponentBase
    {

        public LoginModel LoginUserInfo { get; set; } = new LoginModel();
        public LoginResponse LoginResponse { get; set; } = new LoginResponse();
        [Inject]
        public IRegisterService RegisterService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override Task OnInitializedAsync()
        {

            return base.OnInitializedAsync();
        }
        protected async Task HandleSubmit()
        {
            LoginResponse = await RegisterService.Login(LoginUserInfo);

            if (LoginResponse != null)
            {
                NavigationManager.NavigateTo("/carList");
            }
        }
    }
}
