using es.com.RockectLandingApp.Models;
using es.com.RockectLandingApp.Util;
using es.com.RockectLandingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.com.RockectLandingApp.Business
{
    public class RocketController : IRocketService
    {
        /// <summary>
        /// The available rocket list
        /// </summary>
        readonly List<Rocket> AvailableRocketList = new List<Rocket>();

        private readonly ILandingAreaService _landingAreaService;
        private readonly IPlatformService _platformService;
        private readonly IPositionService _positionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RocketController"/> class.
        /// </summary>
        /// <param name="landingAreaService">The landing area service.</param>
        /// <param name="platformService">The platform service.</param>
        public RocketController(ILandingAreaService landingAreaService, IPlatformService platformService, IPositionService positionService)
        {
            _landingAreaService = landingAreaService;
            _platformService = platformService;
            _positionService = positionService;
        }

        /// <summary>
        /// Asks for position.
        /// </summary>
        /// <param name="landingAreaName">Name of the landing area.</param>
        /// <param name="platforName">Name of the platfor.</param>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <returns></returns>
        public string AskForPosition(string landingAreaName, string platformName, double areaX, double areaY)
        {
            var landingArea = _landingAreaService.GetLandingAreasList()
                .FirstOrDefault(x => x.Description == landingAreaName);

            if (landingArea == null)
                return Constants.LandingAreaNotFound;

            var platform = _landingAreaService.GetPlatformsList(landingAreaName)
                               .FirstOrDefault(x => x.Description == platformName);

            if (platform == null)
                return Constants.PlatformNotFound;

            var platformPositions = _positionService.GetAvailablePlatformPosition(platform);
            var positionAvailable = platformPositions.FirstOrDefault(x => x.PositionX == areaX && x.PositionY == areaY);

            if (positionAvailable == null)
                return Constants.OutOfPlatform;

            if (positionAvailable.IsAvailable)
                return Constants.OkForLanding;             

            return Constants.Clash;
        }



        /// <summary>
        /// Creates the rocket.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Rocket CreateRocket(string name)
        {
            Rocket rocket = new Rocket()
            {
                RocketId = Guid.NewGuid(),
                Description = name
            };

            AvailableRocketList.Add(rocket);

            return rocket;
        }

        /// <summary>
        /// Rockets the list.
        /// </summary>
        /// <returns> the rocket list</returns>
        public List<Rocket> RocketList()
        {
            return AvailableRocketList;
        }
    }
}
