using es.com.RockectLandingApp.Models;
using es.com.RockectLandingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace es.com.RockectLandingApp.Business
{
    public class LandingAreaController : ILandingAreaService
    {

        private readonly List<LandingArea> landingAreaList = new List<LandingArea>();

        private readonly IPositionService _positionService;


        /// <summary>
        /// Initializes a new instance of the <see cref="LandingAreaController"/> class.
        /// </summary>
        /// <param name="positionService">The position service.</param>
        public LandingAreaController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        /// <summary>
        /// Creates the landing zone.
        /// </summary>
        public LandingArea CreateLandingZone(string description, double areaX, double areaY)
        {
            LandingArea landingArea = new LandingArea()
            {
                Id = Guid.NewGuid(),
                Description = description,
                AreaX = areaX,
                AreaY = areaY,
                fieldsX = Math.Sqrt(areaX),
                fieldsY = Math.Sqrt(areaY)
            };

            var positionsList = _positionService.GetPositionsList(landingArea.AreaX, landingArea.AreaY);
            landingArea.AreaPositions = positionsList;
            landingAreaList.Add(landingArea);

            _positionService.AddPosition(landingArea.Id, positionsList);

            return landingArea;
        }

        /// <summary>
        /// Landings the areas list.
        /// </summary>
        /// <returns></returns>
        public List<LandingArea> GetLandingAreasList()
        {
            return landingAreaList;
        }

        /// <summary>
        /// Platformses the list.
        /// </summary>
        /// <param name="langingZoneName"></param>
        /// <returns></returns>
        public List<Platform> GetPlatformsList(string langingZoneName)
        {
            return landingAreaList.Where(x => x.Description == langingZoneName)
                .Select(x => x.AvailablePlatforms).FirstOrDefault();
        }

        /// <summary>
        /// Gets the board.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        /// <returns></returns>
        public StringBuilder GetDrawLandingArea(LandingArea landingArea)
        {
            List<Position> positionList = landingArea.AreaPositions;
            StringBuilder board = new StringBuilder();
            double counter = landingArea.AreaX;

            for (int i = 1; i <= counter; i++)
            {
                var tempList = positionList.Where(p => p.PositionX == i);

                foreach (var item in tempList)
                {
                    var stringPositionX = item.PositionX.ToString().Length <= 1 ? $"0{item.PositionX}" : $"{item.PositionX}";
                    var stringPositionY = item.PositionY.ToString().Length <= 1 ? $"0{item.PositionY}" : $"{item.PositionY}";

                    board.Append($"|{stringPositionX},{stringPositionY}|");
                }
                board.Append(Environment.NewLine);
            }

            return board;
        }

        /// <summary>
        /// Adds the platform.
        /// </summary>
        /// <param name="landingAreaId">The landing area identifier.</param>
        /// <param name="platform">The platform.</param>
        public void AddPlatform(Guid landingAreaId, Platform platform)
        {
            var landingArea = landingAreaList.FirstOrDefault(x => x.Id == landingAreaId);
            landingArea.AvailablePlatforms.Add(platform);
        }
    }
}
