using es.com.RockectLandingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectLandingApp.Interfaces
{
    public interface IRocketService
    {
        /// <summary>
        /// Creates the rocket.
        /// </summary>
        /// <returns></returns>
        public Rocket CreateRocket(string name);

        /// <summary>
        /// Rockets the list.
        /// </summary>
        /// <returns></returns>
        public List<Rocket> RocketList();


        /// <summary>
        /// Asks for position.
        /// </summary>
        /// <param name="landingAreaName">Name of the landing area.</param>
        /// <param name="platformName">Name of the platform.</param>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <returns></returns>
        public string AskForPosition(string  landingAreaName,  string  platformName, double areaX, double areaY);
    }
}
