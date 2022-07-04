using es.com.RockectLandingApp.Interfaces;
using es.com.RockectLandingApp.Models;
using System;

namespace es.com.RockectLandingApp.Services
{
    public class PlatformService : IPlatformService
    {

        private readonly IPositionService _positionService;
        private readonly ILandingAreaService _landingAreaService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformService"/> class.
        /// </summary>
        /// <param name="positionService">The position service.</param>
        public PlatformService(IPositionService positionService, ILandingAreaService landingAreaService)
        {
            _positionService = positionService;
            _landingAreaService = landingAreaService;
        }

        /// <summary>
        /// Creates the landing platform.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        /// <param name="descripcion">The descripcion.</param>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <param name="minRocketSpace">The minimum rocket space.</param>
        /// <returns></returns>
        public Platform CreateLandingPlatform(LandingArea landingArea, string descripcion, double areaX, double areaY, int minRocketSpace, double landingAreaX, double landingAreaY)
        {
            Platform platform = new Platform()
            {
                Id = Guid.NewGuid(),
                LandingArea = landingArea,
                Description = descripcion,
                AreaX = areaX,
                AreaY = areaY,
                MinRocketSpace = minRocketSpace,
                LandingAreaX = landingAreaX,
                LandingAreaY = landingAreaY
            };

            _landingAreaService.AddPlatform(landingArea.Id, platform);

            var positionList = _positionService.GetPositionsList(platform.AreaX, platform.AreaY);
            _positionService.AddPosition(platform.Id, positionList);
            _positionService.PositionatePlatformOnLandingArea(landingArea, platform);

            return platform;
        }
    }
}
