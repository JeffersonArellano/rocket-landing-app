using es.com.RockectLandingApp.Interfaces;
using es.com.RockectLandingApp.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace es.com.RockectLandingApp.Test.Services
{
    [TestFixture]
    public class RocketServiceTest
    {
         
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

    }
}
