using System.Reflection;
using System.Threading.Tasks;
using Blazored.Modal;
using JhipsterExample.Client.Models;
using JhipsterExample.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace JhipsterExample.Client.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationService { get; set; }

        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        public LoginModel LoginModel { get; set; } = new LoginModel();

        public bool IsAuthenticateError { get; set; }

        private async Task HandleSubmit()
        {
            var result = await (AuthenticationService as IAuthenticationService).SignIn(LoginModel);
            IsAuthenticateError = !result;
            LoginModel = new LoginModel();
            if (result)
            {
                await BlazoredModal.CloseAsync();
            }
        }
    }
}
