using RocketLandingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketLandingApp.Interfaces
{
    interface IRocketController
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
    }
}
