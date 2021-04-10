using RocketLandingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketLandingApp.Interfaces
{
    interface ILandingAreaController
    {
        /// <summary>
        /// Creates the landing zone.
        /// </summary>
        public LandingArea CreateLandingZone();


        /// <summary>
        /// Landings the areas list.
        /// </summary>
        /// <returns></returns>
        public List<LandingArea> LandingAreasList();

        /// <summary>
        /// Platformses the list.
        /// </summary>
        /// <returns></returns>
        public List<Platform> PlatformsList(string langingZoneName);

        /// <summary>
        /// Gets the board.
        /// </summary>
        /// <param name="landingArea">The landing area.</param>
        /// <param name="positionList">The position list.</param>
        /// <returns></returns>
        public StringBuilder DrawLandingArea(LandingArea landingArea, List<Position> positionList);
    }
}
