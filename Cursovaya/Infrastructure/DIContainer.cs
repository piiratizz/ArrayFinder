using Microsoft.Extensions.DependencyInjection;

namespace Cursovaya.Infrastructure
{
    internal static class DIContainer
    {
        private static ServiceCollection _services;
        private static ServiceProvider _provider;
        private static bool _builded;

        static DIContainer()
        {
            _services = new ServiceCollection();
            _builded = false;
        }

        public static T GetService<T>()
        {
            if(!_builded)
            {
                throw new Exception("Di container is not builded");
            }

            var service = _provider.GetRequiredService<T>();

            if(service == null)
            {
                throw new NullReferenceException(nameof(service));
            }

            return service;
        }

        public static void BindAsSingle<T>() where T : class
        {
            _services.AddSingleton<T>();
        }

        public static void BindAsSingle<T, V>() where T : class where V : class, T
        {
            _services.AddSingleton<T, V>();
        }

        public static void Build()
        {
            _builded = true;
            _provider = _services.BuildServiceProvider();
        }
    }
}
