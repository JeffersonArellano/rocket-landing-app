using es.com.RockectApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectApp.Interfaces
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
    }
}
