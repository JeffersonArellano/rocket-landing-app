using es.com.RockectApp.Services;
using es.com.RockectLandingApp.Interfaces;
using es.com.RockectLandingApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace RocketLandingApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILandingAreaService, LandingAreaService>()
                .AddSingleton<IPlatformService, PlatformService>()
                .AddSingleton<IRocketService, RocketService>()
                .AddSingleton<IPositionService, PositionService>()
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
