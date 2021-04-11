﻿using es.com.RockectApp.Interfaces;
using es.com.RockectApp.Models;
using es.com.RockectApp.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectApp.Business
{
    public class PlatformController : IPlatformService
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
        public Platform CreateLandingPlatform(LandingArea landingArea, string descripcion, double areaX, double areaY, int minRocketSpace)
        {
            Platform platform = new Platform()
            {
                PlatformId = Guid.NewGuid(),
                LandingArea = landingArea,
                Description = descripcion,
                AreaX = areaX,
                AreaY = areaY,
                MinRocketSpace = minRocketSpace
            };
             
            landingArea.AvailablePlatforms.Add(platform);

            return platform;
        }
    }
}