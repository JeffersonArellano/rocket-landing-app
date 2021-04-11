using es.com.RockectLandingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectLandingApp.Interfaces
{
    public interface ILandingAreaService
    {
        /// <summary>
        /// Creates the landing zone.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <returns></returns>
        public LandingArea CreateLandingZone(string description,  double  areaX, double  areaY);

        /// <summary>
        /// Gets the landing areas list.
        /// </summary>
        /// <returns></returns>
        public List<LandingArea> GetLandingAreasList();

        /// <summary>
        /// Gets the platforms list.
        /// </summary>
        /// <param name="langingZoneName">Name of the langing zone.</param>
        /// <returns></returns>
        public List<Platform> GetPlatformsList(string langingZoneName);

        /// <summary>
        /// Gets the draw landing area.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        /// <returns></returns>
        public StringBuilder GetDrawLandingArea(LandingArea landingArea);

        /// <summary>
        /// Adds the platform.
        /// </summary>
        /// <param name="landingAreaId">The landing area identifier.</param>
        /// <param name="platform">The platform.</param>
        public void AddPlatform(Guid landingAreaId, Platform  platform);

    }
}
