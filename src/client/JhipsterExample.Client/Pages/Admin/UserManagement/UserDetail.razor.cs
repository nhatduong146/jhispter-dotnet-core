using System.Threading.Tasks;
using JhipsterExample.Client.Models;
using JhipsterExample.Client.Pages.Utils;
using JhipsterExample.Client.Services.EntityServices.User;
using Microsoft.AspNetCore.Components;

namespace JhipsterExample.Client.Pages.Admin.UserManagement
{
    public partial class UserDetail : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        private INavigationService NavigationService { get; set; }

        private UserModel CurrentUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CurrentUser = null;
            if (!string.IsNullOrWhiteSpace(Id))
            {
                CurrentUser = await UserService.Get(Id);
            }
        }

        private void Back()
        {
            NavigationService.Previous();
        }
    }
}
