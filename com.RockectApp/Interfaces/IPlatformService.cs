using es.com.RockectApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectApp.Interfaces
{
    public interface IPlatformService
    {
        /// <summary>
        /// Creates the landing platform.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        public Platform CreateLandingPlatform(LandingArea landingArea);
    }
}
