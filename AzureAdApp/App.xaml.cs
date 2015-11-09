using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Unity;

namespace AzureAdApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Microsoft.Practices.Prism.Mvvm.MvvmAppBase
    {
        public static string AdApplicationId = "04305479-54e7-4d59-8aaa-1ad2a9e63f20";
        public static string AdApplicationUnitId = "251162";

        private readonly IUnityContainer _container = new UnityContainer();
        public App()
        {
            //Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
            //    Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
            //    Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();

        }

        public enum Experiences
        {
            Login,
            DashBoard,
            ResourceTemplateGallery
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {

            _container.RegisterInstance(NavigationService);
            ContainerRegistrator.RegisterContainers(_container);
            return System.Threading.Tasks.Task.FromResult<object>(null);
        }

        protected override object Resolve(Type type)
        {
            return _container.Resolve(type);
        }


        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {

            this.NavigationService.Navigate(Experiences.ResourceTemplateGallery.ToString(), null);
            return System.Threading.Tasks.Task.FromResult<object>(null);
        }
    }
}
