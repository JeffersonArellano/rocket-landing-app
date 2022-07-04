using es.com.RockectLandingApp.Interfaces;
using es.com.RockectLandingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.com.RockectLandingApp.Services
{
    public class PositionService : IPositionService
    {
        private readonly List<RegisteredPosition> registeredPositions = new List<RegisteredPosition>();

        /// <summary>
        /// Gets the positions list.
        /// </summary>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <returns></returns>
        public List<Position> GetPositionsList(double areaX, double areaY)
        {
            List<Position> positionsList = new List<Position>();
            Position position;

            for (int x = 1; x <= areaX; x++)
            {
                for (int y = 1; y <= areaY; y++)
                {
                    position = new Position()
                    {
                        PositionX = x,
                        PositionY = y,
                        IsAvailable = true
                    };
                    positionsList.Add(position);
                }
            }
            return positionsList;
        }

        /// <summary>
        /// Adds the position.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <param name="positions">The positions.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddPosition(Guid ownerId, List<Position> positions)
        {
            var registeredPosition = new RegisteredPosition()
            {
                OwnerId = ownerId,
                Positions = positions
            };

            registeredPositions.Add(registeredPosition);
        }

        /// <summary>
        /// Gets the registered positions.
        /// </summary>
        /// <returns></returns>
        public List<RegisteredPosition> GetRegisteredPositions()
        {
            return registeredPositions;
        }

        /// <summary>
        /// Gets the registered positions.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <returns></returns>
        public RegisteredPosition GetRegisteredPositions(Guid ownerId)
        {
            return registeredPositions.FirstOrDefault(x => x.OwnerId == ownerId);
        }

        /// <summary>
        /// Positions the platform in landing area.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        /// <param name="platform">The platform.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void PositionatePlatformOnLandingArea(LandingArea landingArea, Platform platform)
        {
            var landingAreaPositions = registeredPositions.FirstOrDefault(x => x.OwnerId == landingArea.Id);
            var platformPositions = registeredPositions.FirstOrDefault(x => x.OwnerId == platform.Id);

            platformPositions.Positions.ForEach(x =>
            {
                landingAreaPositions.Positions
                .FirstOrDefault(y => y.PositionX == x.PositionX && y.PositionY == x.PositionY).IsAvailable = false;
            });
        }

        /// <summary>
        /// Gets the available platform position.
        /// </summary>
        /// <param name="platform">The platform.</param>
        /// <returns></returns>
        public List<Position> GetAvailablePlatformPosition(Platform platform)
        {
            return registeredPositions.FirstOrDefault(x => x.OwnerId == platform.Id).Positions;
        }

        /// <summary>
        /// Marks the platform position.
        /// </summary>
        /// <param name="landingAreaName">Name of the landing area.</param>
        /// <param name="platformName">Name of the platform.</param>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public Position MarkPlatformPosition(Platform platform, double areaX, double areaY)
        {
            var position = registeredPositions.First(x => x.OwnerId == platform.Id).
                Positions.FirstOrDefault(y => y.PositionX == areaX && y.PositionY == areaY);

            position.IsAvailable = false;
            return position;
        }
    }
}
