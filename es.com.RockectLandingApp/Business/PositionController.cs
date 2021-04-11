﻿using es.com.RockectLandingApp.Models;
using es.com.RockectLandingApp.Interfaces;
using System;
using System.Collections.Generic;

namespace es.com.RockectLandingApp.Business
{
    public class PositionController : IPositionService
    {
        private readonly List<RegisteredPosition> registeredPositions = new List<RegisteredPosition>();

        /// <summary>
        /// Gets the positions list.
        /// </summary>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <returns></returns>
        public List<Position> GetPositionsList(double areaX, double areaY)
        {
            List<Position> positionsList = new List<Position>();
            Position position;

            for (int x = 1; x <= areaX; x++)
            {
                for (int y = 1; y <= areaY; y++)
                {
                    position = new Position()
                    {
                        PositionX = x,
                        PositionY = y
                    };
                    positionsList.Add(position);
                }
            }
            return positionsList;
        }

        /// <summary>
        /// Adds the position.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <param name="positions">The positions.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddPosition(Guid ownerId, List<Position> positions)
        {
            var registeredPosition = new RegisteredPosition()
            {
                OwnerId = ownerId,
                Positions= positions
            };

            registeredPositions.Add(registeredPosition);
        }


    }
}
