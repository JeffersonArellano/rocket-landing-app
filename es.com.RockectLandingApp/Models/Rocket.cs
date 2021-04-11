using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace es.com.RockectLandingApp.Models
{
    public class Rocket
    {
        /// <summary>
        /// Gets or sets the rocket identifier.
        /// </summary>
        /// <value>
        /// The rocket identifier.
        /// </value>
        [Key]
        public Guid RocketId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is landed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is landed; otherwise, <c>false</c>.
        /// </value>
        public bool  IsLanded { get; set; }

        /// <summary>
        /// Gets or sets the position identifier.
        /// </summary>
        /// <value>
        /// The position identifier.
        /// </value>
        public Position PositionId { get; set; }

        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The platform.
        /// </value>
        public Platform Platform { get; set; }
    }
}
