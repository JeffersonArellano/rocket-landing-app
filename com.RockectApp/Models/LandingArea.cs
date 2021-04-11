using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace es.com.RockectApp.Models
{
    public class LandingArea
    {

        public LandingArea()
        {
            AvailablePlatforms = new List<Platform>();
            AreaPositions = new List<Position>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description  { get; set; }

        /// <summary>
        /// Gets or sets the area x.
        /// </summary>
        /// <value>
        /// The area x.
        /// </value>
        public double AreaX { get; set; }

        /// <summary>
        /// Gets or sets the area y.
        /// </summary>
        /// <value>
        /// The area y.
        /// </value>
        public double  AreaY { get; set; }

        /// <summary>
        /// Gets or sets the fields x.
        /// </summary>
        /// <value>
        /// The fields x.
        /// </value>
        public double fieldsX { get; set; }

        /// <summary>
        /// Gets or sets the fields y.
        /// </summary>
        /// <value>
        /// The fields y.
        /// </value>
        public double fieldsY { get; set; }

        /// <summary>
        /// Gets or sets the available platforms.
        /// </summary>
        /// <value>
        /// The available platforms.
        /// </value>
        public List<Platform> AvailablePlatforms { get; set ; }

        /// <summary>
        /// Gets or sets the area positions.
        /// </summary>
        /// <value>
        /// The area positions.
        /// </value>
        public List<Position> AreaPositions { get; set; }
    }
}
