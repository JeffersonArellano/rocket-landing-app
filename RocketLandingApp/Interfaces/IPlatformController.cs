using RocketLandingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketLandingApp.Interfaces
{
    interface IPlatformController
    {
        /// <summary>
        /// Creates the landing platform.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        public Platform CreateLandingPlatform(LandingArea landingArea);
    }
}
