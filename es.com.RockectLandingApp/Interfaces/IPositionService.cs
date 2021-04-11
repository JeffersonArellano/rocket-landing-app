using es.com.RockectApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectLandingApp.Interfaces
{
    public interface IPositionService
    {
        /// <summary>
        /// Gets the positions list.
        /// </summary>
        /// <param name="areaX">The area x.</param>
        /// <param name="areaY">The area y.</param>
        /// <returns></returns>
        public List<Position> GetPositionsList(double areaX, double areaY);
    }
}
