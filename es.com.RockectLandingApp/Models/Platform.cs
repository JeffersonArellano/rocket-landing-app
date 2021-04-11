using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace es.com.RockectLandingApp.Models
{
    public class Platform
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Platform"/> class.
        /// </summary>
        public Platform()
        {
            RocketList = new List<Rocket>();
        }

        /// <summary>
        /// Gets or sets the landing area.
        /// </summary>
        /// <value>
        /// The landing area.
        /// </value>
        public LandingArea LandingArea { get; set; }

        /// <summary>
        /// Gets or sets the platform identifier.
        /// </summary>
        /// <value>
        /// The platform identifier.
        /// </value>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

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
        public double AreaY { get; set; }

        /// <summary>
        /// Gets or sets the minimum rockets space.
        /// </summary>
        /// <value>
        /// The minimum rockets space.
        /// </value>
        public int MinRocketSpace { get; set; }

        /// <summary>
        /// Gets or sets the rocket list.
        /// </summary>
        /// <value>
        /// The rocket list.
        /// </value>
        public List<Rocket> RocketList { get; set; }

        /// <summary>
        /// Gets or sets the landing area x.
        /// </summary>
        /// <value>
        /// The landing area x.
        /// </value>
        public double  LandingAreaX { get; set; }

        /// <summary>
        /// Gets or sets the landing area y.
        /// </summary>
        /// <value>
        /// The landing area y.
        /// </value>
        public double LandingAreaY { get; set; }

    }
}
