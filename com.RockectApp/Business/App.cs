using es.com.RockectApp.Enum;
using es.com.RockectApp.Interfaces;
using es.com.RockectApp.Models;
using es.com.RockectApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace es.com.RockectApp.Business
{
    public class App : IAppService
    {
        #region variables

        readonly ILandingAreaService _landingAreaService;
        readonly IPlatformService _platformService;
        readonly IRocketService _rocketService;


        //readonly LandingAreaController landingAreaController = new LandingAreaController();
        //readonly PlatformController platformController = new PlatformController();
        //readonly RocketController rocketController = new RocketController();

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="landingAreaService">The landing area service.</param>
        /// <param name="platformService">The platform service.</param>
        /// <param name="rocketService">The rocket service.</param>
        public App(ILandingAreaService landingAreaService, IPlatformService platformService, IRocketService rocketService)
        {
            _landingAreaService = landingAreaService;
            _platformService = platformService;
            _rocketService = rocketService;
        }


        public void InitApp()
        {
            string command = string.Empty;

            while (!command.Equals(Constants.Exit))
            {
                command = ConsoleHelpers.ReadConsole("Enter the action to perform, enter \"help\" for command list");

                switch (command)
                {
                    case "help":
                        Console.WriteLine("Valid command list, don't use []");

                        var commandList = System.Enum.GetValues(typeof(ComandLists));

                        foreach (var item in commandList)
                        {
                            var enumType = typeof(ComandLists);
                            Console.WriteLine($"{enumType.GetMember(item.ToString()).Select(x => x.Name)} --> [{item}] ");
                        }
                        break;

                    case "CreateLandingZone":

                        var landingArea = _landingAreaService.CreateLandingZone();
                        if (landingArea != null)
                        {
                            Console.WriteLine("Rocket Created");
                        }
                        else
                        {
                            Console.WriteLine("Error Creating the Rocket");
                        }

                        break;

                    case "LandingZoneList":

                        var landingAreaList = _landingAreaService.LandingAreasList();

                        if (landingAreaList.Any())
                        {
                            landingAreaList.ForEach(x =>
                            Console.WriteLine($"Landing Zone ID: {x.Id} ,  " +
                            $"Landing Area Name: {x.Description} , Total Area: {x.AreaX * x.AreaY}"));
                        }
                        else
                        {
                            Console.WriteLine("No Landing Zones Created");
                        }
                        break;

                    case "CreatePlatform":

                        var availableLandingArea = _landingAreaService.LandingAreasList();

                        if (availableLandingArea.Any())
                        {
                            var landingAreaName = ConsoleHelpers.ReadConsole("Enter the LandingZone name");
                            var selectedLandingArea = availableLandingArea.FirstOrDefault(x => x.Description == landingAreaName);

                            if (selectedLandingArea != null)
                            {
                                _platformService.CreateLandingPlatform(selectedLandingArea);
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

                        break;

                    case "PlatformList":

                        var queryLandingAreaName = ConsoleHelpers.ReadConsole("Enter the LandingZone name");
                        var platformList = _landingAreaService.PlatformsList(queryLandingAreaName);

                        if (platformList != null && platformList.Any())
                        {
                            platformList.ForEach(x => Console.WriteLine($"Platform Id:{x.PlatformId} , Platform Name: {x.Description} , Area {x.AreaX * x.AreaY}m2  "));
                        }
                        else
                        {
                            Console.WriteLine("No Platforms found");
                        }

                        break;

                    case "CreateRocket":

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

                        break;


                    case "RocketList":

                        var availableRockets = _rocketService.RocketList();

                        if (!availableRockets.Any())
                        {
                            Console.WriteLine("No Rockets available");
                            break;
                        }

                        availableRockets.ForEach(x => Console.WriteLine($"Rocket Id \"{x.RocketId}\" , Name \"{x.Description}\""));

                        break;

                    default:
                        Console.WriteLine("Command not found");
                        break;
                }
            }
        }
    }
}
