using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureAdApp.Interfaces.ViewModels;
using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace AzureAdApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel, ILoginPageViewModel
    {
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Login screen";
        }

        public string Title { get; set; }
    }
}
