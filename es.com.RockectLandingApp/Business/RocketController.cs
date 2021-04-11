﻿using es.com.RockectApp.Interfaces;
using es.com.RockectApp.Models;
using es.com.RockectApp.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectApp.Business
{
    public class RocketController : IRocketService
    {
        /// <summary>
        /// The available rocket list
        /// </summary>
        readonly List<Rocket> AvailableRocketList = new List<Rocket>();

        /// <summary>
        /// Creates the rocket.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Rocket CreateRocket(string  name)
        {
            Rocket rocket = new Rocket()
            {
                RocketId = Guid.NewGuid(),
                Description = name
            };

            AvailableRocketList.Add(rocket);

            return rocket;
        }      

        /// <summary>
        /// Rockets the list.
        /// </summary>
        /// <returns> the rocket list</returns>
        public List<Rocket> RocketList()
        {
            return this.AvailableRocketList;
        }
    }
}