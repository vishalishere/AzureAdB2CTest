using Microsoft.Practices.Unity;

namespace AzureAdApp
{
    public static class ContainerRegistrator
    {
        private static IUnityContainer _container;

        public static void RegisterContainers(IUnityContainer container)
        {
            _container = container;
            RegisterCommon();
        }

        private static void RegisterCommon()
        {

        }
    }
}
