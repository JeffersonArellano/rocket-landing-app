using System;
using System.Collections.Generic;
using System.Text;

namespace es.com.RockectLandingApp.Models
{
    public class RegisteredPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredPosition"/> class.
        /// </summary>
        public RegisteredPosition()
        {
            Positions = new List<Position>();
        }
        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>
        /// The positions.
        /// </value>
        public List<Position> Positions { get; set; }
    }
}
