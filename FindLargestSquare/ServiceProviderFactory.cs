using System;
using BusinessLogic.Square;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace PreliminaryAssessment
{
    /// <summary>
    /// Provides Microsoft.Extensions.DependencyInjection.ServiceCollection
    /// </summary>
    public class ServiceProviderFactory
    {
        private static IServiceProvider _serviceProvider;

        static ServiceProviderFactory()
        {
            IServiceCollection services = new ServiceCollection();

            ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
                builder.AddSimpleConsole());

            services.AddTransient(typeof(ISquareService), typeof(SquareService));
        }

        public static  T GetService<T>() where T : class
            => (T)_serviceProvider.GetService(typeof(T));
    }
}
