using Microsoft.Practices.Unity;

namespace AzureAdApp
{
    public static class ContainerRegistrator
    {
        private static IUnityContainer _container;

        public static void RegisterContainers(IUnityContainer container)
        {
            _container = container;
            RegisterSubscription();
            RegisterResourceGallery();
        }

        private static void RegisterResourceGallery()
        {
            //_container
            //    .RegisterType<IResourceTemplateGalleryManager, ResourceTemplateGalleryManager>(
            //            new ContainerControlledLifetimeManager());
            //_container
            //    .RegisterType<IResourceTemplateGalleryRepository, ResourceTemplateGalleryRepository>(
            //        new ContainerControlledLifetimeManager());

        }
        private static void RegisterSubscription()
        {
        //    _container
        //        .RegisterType<ISubscriptionManager, SubscriptionManager>(
        //        new ContainerControlledLifetimeManager());
        //    _container
        //        .RegisterType<ISubscriptionRepository, SubscriptionRepository>(
        //            new ContainerControlledLifetimeManager());
        //    _container
        //        .RegisterType<ISubscriptionFactory, SubscriptionFactory>(
        //            new ContainerControlledLifetimeManager());
        }

    }
}
