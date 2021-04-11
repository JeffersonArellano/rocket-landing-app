using es.com.RockectApp.Interfaces;
using es.com.RockectApp.Models;
using es.com.RockectApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace es.com.RockectApp.Business
{
    public class LandingAreaController : ILandingAreaService
    {

        private readonly List<LandingArea> landingAreaList = new List<LandingArea>();

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
            };

            var positionsList = GetPositionsList(landingArea);
            landingArea.AreaPositions = positionsList;
            landingAreaList.Add(landingArea);

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
        /// Gets the positions list.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        /// <returns></returns>
        private List<Position> GetPositionsList(LandingArea landingArea)
        {
            List<Position> positionsList;
            Position position;

            landingArea.fieldsX = Math.Sqrt(landingArea.AreaX);
            landingArea.fieldsY = Math.Sqrt(landingArea.AreaY);
            positionsList = new List<Position>();

            for (int x = 1; x <= landingArea.AreaX; x++)
            {
                for (int y = 1; y <= landingArea.AreaY; y++)
                {
                    position = new Position()
                    {
                        PositionX = x,
                        PositionY = y
                    };
                    positionsList.Add(position);
                }
            }

            return positionsList;
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
    }
}
