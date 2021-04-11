using es.com.RockectApp.Models;
using es.com.RockectLandingApp.Interfaces;
using System;
using System.Collections.Generic;

namespace es.com.RockectLandingApp.Business
{
    public class PositionController : IPositionService
    {
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
    }
}
