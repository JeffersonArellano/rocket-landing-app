using RocketLandingApp.Interfaces;
using RocketLandingApp.Models;
using RocketLandingApp.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketLandingApp.Business
{
    public class PlatformController : IPlatformController
    { 
        /// <summary>
        /// Creates the landing platform.
        /// </summary>
        /// <param name="landingArea"></param>
        public Platform CreateLandingPlatform(LandingArea landingArea)
        {
            Platform platform = new Platform()
            {
                PlatformId = Guid.NewGuid(),
                LandingArea = landingArea,
                Description = ConsoleHelpers.ReadConsole("Please enter the Platform description"),
                AreaX = long.Parse(ConsoleHelpers.ReadConsole("Please enter Area X")),
                AreaY = long.Parse(ConsoleHelpers.ReadConsole("Please enter Area Y")),
                MinRocketSpace = Convert.ToInt32(ConsoleHelpers.ReadConsole("Please enter the minimum space between rockets"))
            };

            Console.WriteLine($"You going to create the  Platform \"{platform.Description}\", " +
                $"with a total area of \"{platform.AreaX * platform.AreaY}\" m2");

            var confirm = ConsoleHelpers.ConfirmationPrompt("Are you sure to create this platform?");

            if (confirm)
            {
                var zoneArea = landingArea.AreaX * landingArea.AreaY;
                var platformArea = platform.AreaX * platform.AreaY;

                while (platformArea > zoneArea)
                {
                    Console.WriteLine($"Invalid Platform area,  should be less than {zoneArea} m2");
                    platform.AreaX = long.Parse(ConsoleHelpers.ReadConsole("Please enter Area X"));
                    platform.AreaY = long.Parse(ConsoleHelpers.ReadConsole("Please enter Area Y"));

                    platformArea = platform.AreaX * platform.AreaY;
                }

                Console.WriteLine($"Platform created");
                landingArea.AvailablePlatforms.Add(platform);

                return platform; 
            }
            else
            {
                Console.WriteLine($"You discarted the changes");
                return null;
            }
        }
    }
}
