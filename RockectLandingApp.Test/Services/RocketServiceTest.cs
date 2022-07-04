using AutoFixture;
using AutoFixture.AutoMoq;
using es.com.RockectLandingApp.Interfaces;
using es.com.RockectLandingApp.Models;
using es.com.RockectLandingApp.Services;
using es.com.RockectLandingApp.Util;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace RockectLandingApp.Test
{
    [TestFixture]
    public class RocketServiceTest
    {
        private IFixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = CreateMockFixture();
            CustomMockobjects();
        }


        [TestCase("Rocket1")]
        [TestCase("Rocket2")]
        [TestCase("Rocket3")]
        public void CreateRocket_ReturnRocket_WhenCall(string rocketName)
        {
            //Arrange
            var mockILandingAreaService = new Mock<ILandingAreaService>();
            var mockIPlatformService = new Mock<IPlatformService>();
            var mockIPositionService = new Mock<IPositionService>();

            var rocketService = new RocketService(
                mockILandingAreaService.Object,
                mockIPlatformService.Object,
                mockIPositionService.Object
            );

            //Act 
            var sut = rocketService.CreateRocket(rocketName);

            //Assert 
            sut.Should().NotBeNull();
            sut.Description.Should().BeEquivalentTo(rocketName);
        }

        [Test]
        public void RocketList_ReturnEmptyRocketList_WhenCall()
        {
            //Arrange
            var mockILandingAreaService = new Mock<ILandingAreaService>();
            var mockIPlatformService = new Mock<IPlatformService>();
            var mockIPositionService = new Mock<IPositionService>();

            var rocketService = new RocketService(
                mockILandingAreaService.Object,
                mockIPlatformService.Object,
                mockIPositionService.Object
            );

            //Act 
            var sut = rocketService.RocketList();

            //Assert 
            sut.Should().NotBeNull();
            sut.Should().BeEmpty();
        }

        [TestCase(10)]
        [TestCase(100)]
        public void RocketList_ReturnRocketList_WhenHasElements(int rockets)
        {
            //Arrange
            var mockILandingAreaService = new Mock<ILandingAreaService>();
            var mockIPlatformService = new Mock<IPlatformService>();
            var mockIPositionService = new Mock<IPositionService>();

            var rocketService = new RocketService(
                mockILandingAreaService.Object,
                mockIPlatformService.Object,
                mockIPositionService.Object
            );

            for (int i = 1; i <= rockets; i++)
            {
                rocketService.CreateRocket($"Rocket{i}");
            }

            //Act 
            var sut = rocketService.RocketList();

            //Assert 
            sut.Should().NotBeNull();
            sut.Should().HaveCount(rockets);
        }

        [Test]
        public void AskForPosition_ReturnLandingAreaNotFound_WhenLandingAreaIsNull()
        {
            //Arrange
            string landingAreaName = "landingArea1";

            var mockILandingAreaService = new Mock<ILandingAreaService>();
            var mockIPlatformService = new Mock<IPlatformService>();
            var mockIPositionService = new Mock<IPositionService>();

            mockILandingAreaService.Setup(x => x.GetLandingAreasList()).Returns(new List<LandingArea>());

            var rocketService = new RocketService(
                mockILandingAreaService.Object,
                mockIPlatformService.Object,
                mockIPositionService.Object
            );

            //Act
            var sut = rocketService.AskForPosition(landingAreaName, It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>());

            //Assert
            sut.Should().NotBeNull();
            sut.Should().BeEquivalentTo(StringConstants.LandingAreaNotFound);
            mockILandingAreaService.Verify(x => x.GetLandingAreasList(), Times.Once);
        }

        [Test]
        public void AskForPosition_ReturnPlatformNotFound_WhenPlatformIsNull()
        {
            //Arrange
            string landingAreaName = "landingArea1";

            var mockILandingAreaService = new Mock<ILandingAreaService>();
            var mockIPlatformService = new Mock<IPlatformService>();
            var mockIPositionService = new Mock<IPositionService>();

            mockILandingAreaService.Setup(x => x.GetLandingAreasList()).Returns(_fixture.CreateMany<LandingArea>().ToList());
            mockILandingAreaService.Setup(x => x.GetPlatformsList(It.IsAny<string>())).Returns(new List<Platform>());

            var rocketService = new RocketService(
                mockILandingAreaService.Object,
                mockIPlatformService.Object,
                mockIPositionService.Object
            );

            //Act
            var sut = rocketService.AskForPosition(landingAreaName, It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>());

            //Assert
            sut.Should().NotBeNull();
            sut.Should().BeEquivalentTo(StringConstants.PlatformNotFound);
            mockILandingAreaService.Verify(x => x.GetLandingAreasList(), Times.Once);
            mockILandingAreaService.Verify(x => x.GetPlatformsList(It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void AskForPosition_ReturnOutOfPlatform_WhenPositionAvailableIsNull()
        {
            //Arrange
            string landingAreaName = "landingArea1";
            string platformName = "platform1";

            var mockILandingAreaService = new Mock<ILandingAreaService>();
            var mockIPlatformService = new Mock<IPlatformService>();
            var mockIPositionService = new Mock<IPositionService>();

            mockILandingAreaService.Setup(x => x.GetLandingAreasList()).Returns(_fixture.CreateMany<LandingArea>().ToList());
            mockILandingAreaService.Setup(x => x.GetPlatformsList(It.IsAny<string>())).Returns(_fixture.CreateMany<Platform>().ToList());

            mockIPositionService.Setup(x => x.GetAvailablePlatformPosition(It.IsAny<Platform>())).Returns(_fixture.CreateMany<Position>().ToList());

            var rocketService = new RocketService(
                mockILandingAreaService.Object,
                mockIPlatformService.Object,
                mockIPositionService.Object
            );

            //Act
            var sut = rocketService.AskForPosition(landingAreaName, platformName, It.IsAny<double>(), It.IsAny<double>());

            //Assert
            sut.Should().NotBeNull();
            sut.Should().BeEquivalentTo(StringConstants.OutOfPlatform);
            mockILandingAreaService.Verify(x => x.GetLandingAreasList(), Times.Once);
            mockILandingAreaService.Verify(x => x.GetPlatformsList(It.IsAny<string>()), Times.Once);
            mockIPositionService.Verify(x => x.GetAvailablePlatformPosition(It.IsAny<Platform>()), Times.Once);
        }

        [Test]
        public void AskForPosition_ReturnOkForLanding_WhenPositionIsAvailable()
        {
            //Arrange
            string landingAreaName = "landingArea1";
            string platformName = "platform1";
            double areaX = 1;
            double areaY = 1;

            var mockILandingAreaService = new Mock<ILandingAreaService>();
            var mockIPlatformService = new Mock<IPlatformService>();
            var mockIPositionService = new Mock<IPositionService>();

            mockILandingAreaService.Setup(x => x.GetLandingAreasList()).Returns(_fixture.CreateMany<LandingArea>().ToList());
            mockILandingAreaService.Setup(x => x.GetPlatformsList(It.IsAny<string>())).Returns(_fixture.CreateMany<Platform>().ToList());
            mockIPositionService.Setup(x => x.GetAvailablePlatformPosition(It.IsAny<Platform>())).Returns(_fixture.CreateMany<Position>().ToList());

            var rocketService = new RocketService(
                mockILandingAreaService.Object,
                mockIPlatformService.Object,
                mockIPositionService.Object
            );

            //Act
            var sut = rocketService.AskForPosition(landingAreaName, platformName, areaX, areaY);

            //Assert
            sut.Should().NotBeNull();
            sut.Should().BeEquivalentTo(StringConstants.OkForLanding);
            mockILandingAreaService.Verify(x => x.GetLandingAreasList(), Times.Once);
            mockILandingAreaService.Verify(x => x.GetPlatformsList(It.IsAny<string>()), Times.Once);
            mockIPositionService.Verify(x => x.GetAvailablePlatformPosition(It.IsAny<Platform>()), Times.Once);
        }

         
        private void CustomMockobjects()
        {
            _fixture.Customize<LandingArea>
                (landingArea => landingArea
                .With(la => la.Description, "landingArea1"));

            _fixture.Customize<Platform>
                (platform => platform
                .With(pf => pf.Description, "platform1"));

            _fixture.Customize<Position>
               (position => position
               .With(pt => pt.PositionX, 1)
               .With(pt => pt.PositionY, 1)
               );
        }

        private static IFixture CreateMockFixture()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        }
    }
}