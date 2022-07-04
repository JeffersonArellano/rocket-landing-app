using es.com.RockectApp.Interfaces;
using es.com.RockectLandingApp.Enum;
using es.com.RockectLandingApp.Interfaces;
using es.com.RockectLandingApp.Util;
using System;
using System.Linq;

namespace es.com.RockectApp.Services
{
    public class App : IAppService
    {
        #region variables

        private readonly ILandingAreaService _landingAreaService;
        private readonly IPlatformService _platformService;
        private readonly IRocketService _rocketService;
        private readonly IPositionService _positionService;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="landingAreaService">The landing area service.</param>
        /// <param name="platformService">The platform service.</param>
        /// <param name="rocketService">The rocket service.</param>
        public App(ILandingAreaService landingAreaService, IPlatformService platformService, IRocketService rocketService, IPositionService positionService)
        {
            _landingAreaService = landingAreaService;
            _platformService = platformService;
            _rocketService = rocketService;
            _positionService = positionService;
        }

        public void InitApp()
        {
            string command = string.Empty;

            while (!command.Equals(StringConstants.Exit))
            {
                command = ConsoleHelpers.ReadConsole("Enter the action to perform, enter \"help\" for command list");

                switch (command)
                {
                    case "help":
                        help();
                        break;

                    case "CreateLandingArea":
                        CreateLandingArea();
                        break;

                    case "LandingAreaList":
                        GetLandingAreaList();
                        break;

                    case "DrawLandingArea":
                        DrawLandingArea();
                        break;

                    case "CreatePlatform":
                        CreatePlatform();
                        break;

                    case "PlatformList":
                        GetPlaformList();
                        break;

                    case "CreateRocket":
                        CreateRocket();
                        break;

                    case "RocketList":
                        GetRocketList();
                        break;

                    case "AskForPosition":
                        AskForPosition();
                        break;
                    default:
                        Console.WriteLine("Command not found");
                        break;
                }
            }
        }

        private void RequestPosition()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asks for position.
        /// </summary>
        private void AskForPosition()
        {
            var landingAreaName = ConsoleHelpers.ReadConsole("Enter the landing area name");
            var platformName = ConsoleHelpers.ReadConsole("Enter the platform name");
            var positionX = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter the position X"));
            var positionY = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter the position Y"));

            var answer = _rocketService.AskForPosition(landingAreaName, platformName, positionX, positionY);

            ConsoleHelpers.WriteLine($"The answer from control center was \"{answer}\"", "warning");

            if (answer.Equals(StringConstants.OkForLanding))
            {
                var confirm = ConsoleHelpers.ConfirmationPrompt("Request this position ? ");

                if (confirm)
                {
                    var platform = _landingAreaService.GetPlatformsList(landingAreaName)
                                       .FirstOrDefault(x => x.Description == platformName);

                    var position = _positionService.MarkPlatformPosition(platform, positionX, positionY);
                    if (!position.IsAvailable)
                    {
                        ConsoleHelpers.WriteLine($"Position requested successful", "ok");
                    }
                    else
                    {
                        ConsoleHelpers.WriteLine($"Error requesting the position ", "alert");
                    }
                }
            }


        }

        /// <summary>
        /// Helps this instance.
        /// </summary>
        private void help()
        {
            var commandList = System.Enum.GetNames(typeof(ConsoleComands));
            Console.WriteLine("Valid command list, don't use []");

            foreach (var item in commandList)
            {
                Console.WriteLine($"[{item}] ");
            }
        }

        /// <summary>
        /// Gets the rocket list.
        /// </summary>
        private void GetRocketList()
        {
            var availableRockets = _rocketService.RocketList();

            if (!availableRockets.Any())
            {
                Console.WriteLine("No Rockets available");
            }

            availableRockets.ForEach(x => Console.WriteLine($"Rocket Id \"{x.RocketId}\" , Name \"{x.Description}\""));

        }

        /// <summary>
        /// Creates the rocket.
        /// </summary>
        private void CreateRocket()
        {
            var name = ConsoleHelpers.ReadConsole("Enter the Rocket Name");
            var rocket = _rocketService.CreateRocket(name);

            if (rocket != null)
            {
                Console.WriteLine("Rocket Created");
            }
            else
            {
                Console.WriteLine("Error Creating the Rocket");
            }
        }

        /// <summary>
        /// Gets the plaform list.
        /// </summary>
        private void GetPlaformList()
        {
            var queryLandingAreaName = ConsoleHelpers.ReadConsole("Enter the LandingZone name");
            var platformList = _landingAreaService.GetPlatformsList(queryLandingAreaName);

            if (platformList != null && platformList.Any())
            {
                platformList.ForEach(x => Console.WriteLine($"Platform Id:{x.Id} , Platform Name: {x.Description} , Area {x.AreaX * x.AreaY}m2  "));
            }
            else
            {
                Console.WriteLine("No Platforms found");
            }
        }

        /// <summary>
        /// Draws the landing area.
        /// </summary>
        private void DrawLandingArea()
        {
            var drawLandingAreaName = ConsoleHelpers.ReadConsole("Enter the Landing Area Name");
            var drawLandingArea = _landingAreaService.GetLandingAreasList()
                .FirstOrDefault(x => x.Description == drawLandingAreaName);

            if (drawLandingArea != null)
            {
                Console.WriteLine(_landingAreaService.GetDrawLandingArea(drawLandingArea));
            }
            else
            {
                Console.WriteLine("Not Landing Area found.");
            }
        }

        /// <summary>
        /// Gets the landing area list.
        /// </summary>
        private void GetLandingAreaList()
        {

            var landingAreaList = _landingAreaService.GetLandingAreasList();

            if (landingAreaList.Any())
            {
                landingAreaList.ForEach(x =>
                Console.WriteLine($"Landing Zone ID: {x.Id} ,  " +
                $"Landing Area Name: {x.Description} , Total Area: {x.AreaX * x.AreaY}"));
            }
            else
            {
                Console.WriteLine("No Landing Areas Found");
            }
        }

        /// <summary>
        /// Creates the landing area.
        /// </summary>
        private void CreateLandingArea()
        {
            var areaDescription = ConsoleHelpers.ReadConsole("Enter the landing zone description");
            var areaX = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter the Area x"));
            var areaY = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter the Area Y"));

            Console.WriteLine($"You going to create the new landing zone \"{areaDescription}\", " +
                $"with a total area of \"{areaX * areaY}\" m2");

            var confirm = ConsoleHelpers.ConfirmationPrompt("Are you sure to create this landing zone?");

            if (confirm)
            {
                var landingArea = _landingAreaService.CreateLandingZone(areaDescription, areaX, areaY);

                if (landingArea == null)
                {
                    Console.WriteLine("No Landing Area Created");
                }
                Console.WriteLine("Landing Area Created");
            }
            Console.WriteLine("Operation canceled");
        }

        /// <summary>
        /// Creates the platform.
        /// </summary>
        private void CreatePlatform()
        {
            var availableLandingArea = _landingAreaService.GetLandingAreasList();

            if (availableLandingArea.Any())
            {
                var landingAreaName = ConsoleHelpers.ReadConsole("Enter the LandingZone name");
                var selectedLandingArea = availableLandingArea.FirstOrDefault(x => x.Description == landingAreaName);

                if (selectedLandingArea != null)
                {

                    var platformDescription = ConsoleHelpers.ReadConsole("Enter the Platform description");
                    var platformAreaX = Convert.ToDouble(ConsoleHelpers.ReadConsole("Anter Area X"));
                    var platformAreaY = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter Area Y"));
                    var platformMinRocketSpace = Convert.ToInt32(ConsoleHelpers.ReadConsole("Enter the minimum space between rockets"));

                    var platformConfirm = ConsoleHelpers.ConfirmationPrompt("Are you sure to create this platform?");

                    if (platformConfirm)
                    {
                        var zoneArea = selectedLandingArea.AreaX * selectedLandingArea.AreaY;
                        var platformArea = platformAreaX * platformAreaY;

                        while (platformArea > zoneArea)
                        {
                            Console.WriteLine($"Invalid Platform area,  should be less than {zoneArea} m2");
                            platformAreaX = long.Parse(ConsoleHelpers.ReadConsole("Enter Area X"));
                            platformAreaY = long.Parse(ConsoleHelpers.ReadConsole("Enter Area Y"));

                            platformArea = platformAreaX * platformAreaY;
                        }

                        bool availablePosition = false;
                        double landingAreaX = 0;
                        double landingAreaY = 0;

                        while (!availablePosition)
                        {
                            landingAreaX = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter Landing Area X coordinate for the new platform"));
                            landingAreaY = Convert.ToDouble(ConsoleHelpers.ReadConsole("Enter Landing Area Y coordinate for the new platform"));

                            var landingAreaPositions = _positionService.GetRegisteredPositions()
                                                       .FirstOrDefault(x => x.OwnerId == selectedLandingArea.Id);

                            var positionAvailability = landingAreaPositions.Positions.FirstOrDefault(x => x.PositionX == landingAreaX && x.PositionY == landingAreaY);
                            if (positionAvailability != null)
                            {
                                availablePosition = positionAvailability.IsAvailable;
                            }
                            else
                            {
                                ConsoleHelpers.WriteLine("Invalid coordinate,  try again", "alert");
                            }
                        }

                        var createdPlatform = _platformService.CreateLandingPlatform(selectedLandingArea, platformDescription, platformAreaX, platformAreaY, platformMinRocketSpace, landingAreaX, landingAreaY);

                        if (createdPlatform == null)
                        {
                            Console.WriteLine("Error creating the new platform");

                        }
                        Console.WriteLine("Platform created");
                    }
                }
                else
                {
                    Console.WriteLine("No Landing Area found");
                }
            }
            else
            {
                Console.WriteLine("No Landing Areas found");
            }
        }
    }
}
