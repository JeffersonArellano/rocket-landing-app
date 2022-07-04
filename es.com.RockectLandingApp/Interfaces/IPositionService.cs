using es.com.RockectLandingApp.Models;
using System;
using System.Collections.Generic;

namespace es.com.RockectLandingApp.Interfaces
{
    public interface IPositionService
    {
        /// <summary>
        /// Gets the positions list.
        /// </summary>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <returns></returns>
        public List<Position> GetPositionsList(double areaX, double areaY);

        /// <summary>
        /// Adds the position.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <param name="positions">The positions.</param>
        public void AddPosition(Guid ownerId, List<Position> positions);

        /// <summary>
        /// Gets the registered positions.
        /// </summary>
        /// <returns></returns>
        public List<RegisteredPosition> GetRegisteredPositions();

        /// <summary>
        /// Gets the registered positions.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <returns></returns>
        public RegisteredPosition GetRegisteredPositions(Guid ownerId);

        /// <summary>
        /// Positions the platform in landing area.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        /// <param name="platform">The platform.</param>
        public void PositionatePlatformOnLandingArea(LandingArea landingArea, Platform platform);

        /// <summary>
        /// Gets the available platform position.
        /// </summary>
        /// <param name="platform">The platform.</param>
        /// <returns></returns>
        public List<Position> GetAvailablePlatformPosition(Platform platform);

        /// <summary>
        /// Marks the platform position.
        /// </summary>
        /// <param name="landingAreaName">Name of the landing area.</param>
        /// <param name="platformName">Name of the platform.</param>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        public Position MarkPlatformPosition(Platform platform, double areaX, double areaY);

    }
}
