using es.com.RockectApp.Business;
using es.com.RockectApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace RocketLandingApp
{
    static class Program
    {   
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILandingAreaService, LandingAreaController>()
                .AddSingleton<IPlatformService, PlatformController>()
                .AddSingleton<IRocketService, RocketController>()
                .BuildServiceProvider();


            var landingAreaService = serviceProvider.GetService<ILandingAreaService>();
            var platformService = serviceProvider.GetService<IPlatformService>();
            var rocketService = serviceProvider.GetService<IRocketService>();

            App app = new App(landingAreaService, platformService, rocketService);
            app.InitApp();
        }       
    }
}
