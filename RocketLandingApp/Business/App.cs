using RocketLandingApp.Enum;
using RocketLandingApp.Interfaces;
using RocketLandingApp.Models;
using RocketLandingApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketLandingApp.Business
{
    public class App : IApp
    {
        #region variables

        readonly LandingAreaController landingAreaController = new LandingAreaController();
        readonly PlatformController platformController = new PlatformController();
        readonly RocketController rocketController = new RocketController();

        #endregion

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

                        var commandList = System.Enum.GetNames(typeof(ComandLists)).OrderBy(x => x);

                        foreach (var item in commandList)
                        {
                            Console.WriteLine($"[{item}] ");
                        }
                        break;

                    case "CreateLandingZone":

                        var landingArea = landingAreaController.CreateLandingZone();
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

                        var landingAreaList = landingAreaController.LandingAreasList();

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

                        var availableLandingArea = landingAreaController.LandingAreasList();

                        if (availableLandingArea.Any())
                        {
                            var landingAreaName = ConsoleHelpers.ReadConsole("Enter the LandingZone name");
                            var selectedLandingArea = availableLandingArea.FirstOrDefault(x => x.Description == landingAreaName);

                            if (selectedLandingArea != null)
                            {
                                platformController.CreateLandingPlatform(selectedLandingArea);
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
                        var platformList = landingAreaController.PlatformsList(queryLandingAreaName);

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
                        var rocket = rocketController.CreateRocket(name);

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

                        var availableRockets = rocketController.RocketList();

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
