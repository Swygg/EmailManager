using BLL.Classes;
using BLL.Interfaces;
using DAL.Classes;
using DAL.Interfaces;
using IHM_Console.Classes;
using IHM_Console.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IHM_Console.Helpers
{
    public static class DependencyInjectionHelper
    {
        private static ServiceProvider? _serviceProvider = null;

        public static ServiceProvider GetServiceProvider()
        {
            if (_serviceProvider == null)
            {
                _serviceProvider = new ServiceCollection()

                //DAL
                .AddScoped<IHostersDalManager, HostersDalManager>()
                .AddScoped<IEmailAccountsDalManager, EmailAccountsDalManager>()
                .AddScoped<IEmailsDalManager, EmailsDalManager>()

                //BLL
                .AddScoped<IHostersBllManager, HostersBllManager>()
                .AddScoped<IEmailAccountsBllManager, EmailAccountsBllManager>()
                .AddScoped<IEmailsBllManager, EmailsBllManager>()

                //IHM
                .AddScoped<IIhm, Ihm>()


                //End
                .BuildServiceProvider();
            }
            return _serviceProvider;
        }
    }
}
