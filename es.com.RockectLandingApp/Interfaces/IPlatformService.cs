using es.com.RockectLandingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectLandingApp.Interfaces
{
    public interface IPlatformService
    {
        /// <summary>
        /// Creates the landing platform.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        /// <param name="descripcion">The descripcion.</param>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <param name="minRocketSpace">The minimum rocket space.</param>
        /// <returns></returns>
        public Platform CreateLandingPlatform(LandingArea landingArea, string descripcion,  double  areaX,  double  areaY,  int minRocketSpace, double landingAreaX, double landingAreaY);
    }
}
