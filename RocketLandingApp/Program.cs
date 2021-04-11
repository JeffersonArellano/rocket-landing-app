using es.com.RockectApp.Business;
using es.com.RockectLandingApp.Business;
using es.com.RockectLandingApp.Interfaces;
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
                .AddSingleton<IPositionService, PositionController>()
                .BuildServiceProvider();


            var landingAreaService = serviceProvider.GetService<ILandingAreaService>();
            var platformService = serviceProvider.GetService<IPlatformService>();
            var rocketService = serviceProvider.GetService<IRocketService>();
            var positionService = serviceProvider.GetService<IPositionService>();

            App app = new App(landingAreaService, platformService, rocketService, positionService);
            app.InitApp();
        }       
    }
}
