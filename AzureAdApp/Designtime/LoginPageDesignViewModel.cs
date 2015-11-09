using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureAdApp.Interfaces.ViewModels;

namespace AzureAdApp.Designtime
{
    public class LoginPageDesignViewModel : ILoginPageViewModel
    {
        public LoginPageDesignViewModel()
        {
            this.Title = "Application login";
        }

        public string Title{get; set;}
    }
}
