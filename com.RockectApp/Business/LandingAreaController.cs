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
        private readonly List<Platform> platformsList = new List<Platform>();

        /// <summary>
        /// Creates the landing zone.
        /// </summary>
        public LandingArea CreateLandingZone()
        {
            LandingArea landingArea = new LandingArea()
            {
                Id = Guid.NewGuid(),
                Description = ConsoleHelpers.ReadConsole("Enter the landing zone description"),
                AreaX = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter the Area x")),
                AreaY = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter the Area Y")),
            };

            Console.WriteLine($"You going to create the new landing zone \"{landingArea.Description}\", with a total area of \"{landingArea.AreaX * landingArea.AreaY}\" m2");

            var confirm = ConsoleHelpers.ConfirmationPrompt("Are you sure to create this landing zone?");
            if (confirm)
            {
                var positionsList = GetPositionsList(landingArea);
                landingArea.AreaPositions = positionsList;

                landingAreaList.Add(landingArea);

                Console.WriteLine($"New Landing zone created");

                return landingArea;
            }
            else
            {
                Console.WriteLine($"You discarted the changes");
                return null;
            }
        }

        /// <summary>
        /// Landings the areas list.
        /// </summary>
        /// <returns></returns>
        public List<LandingArea> LandingAreasList()
        {
            return landingAreaList;
        }

        /// <summary>
        /// Platformses the list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Platform> PlatformsList(string langingZoneName)
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


        public StringBuilder DrawLandingArea(LandingArea landingArea, List<Position> positionList)
        {
            StringBuilder board = new StringBuilder();
            double counter = landingArea.AreaX;

            for (int i = 1; i <= counter; i++)
            {
                var tempList = positionList.Where(p => p.PositionX == i);

                foreach (var item in tempList)
                {
                    var stringPositionX = item.PositionX.ToString().Length <= 1 ? $"0{item.PositionX}" : $"{item.PositionX}";
                    var stringPositionY = item.PositionY.ToString().Length <= 1 ? $"0{item.PositionY}" : $"{item.PositionY}";

                    board.Append($"[{stringPositionX},{stringPositionY}]");
                }
                board.Append(Environment.NewLine);
            }

            return board;
        }
    }
}
