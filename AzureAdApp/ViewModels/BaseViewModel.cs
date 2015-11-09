using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
namespace AzureAdApp.ViewModels
{
    public abstract class BaseViewModel : Microsoft.Practices.Prism.Mvvm.ViewModel
    {
        private INavigationService _navigator;
        protected BaseViewModel(INavigationService nav)
        {
            _navigator = nav;
        }
        public void NavigateTo(string view, object navparam)
        {
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => _navigator.Navigate(view, navparam));

        }
    }
}
