using LightningAlert.Model;
using LightningAlert.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LightningAlert.UnitTests.Services
{
    public class LightningServiceTest
    {
        private Mock<ILogger<LightningService>> _loggerMock;
        private Mock<IAssetService> _assetServiceMock;
        private Mock<INotificationService> _notificationServiceMock;
        public LightningServiceTest()
        {
            _loggerMock = new Mock<ILogger<LightningService>>();
            _assetServiceMock = new Mock<IAssetService>();
            _notificationServiceMock = new Mock<INotificationService>();
        }

        [Fact]
        public void ProcessLightningStrike_Check_Notification_With_Valid_Data()
        {
            Asset mockAsset = new Asset()
            {
                assetName = "Luvinia Union",
                quadKey = "033321123133",
                assetOwner = "7100"
            };
            List<Asset> mockResult = new List<Asset>() { mockAsset };

            LightningStrike mockLightningStrike = new LightningStrike()
            {
                flashType = 1,
                strikeTime = 1446760902720,
                latitude = 8.8400666,
                longitude = -12.7052625,
                peakAmps = 3363,
                reserved = "000",
                icHeight = 18467,
                receivedTime = 1446760915182,
                numberOfSensors = 8,
                multiplicity = 3
            };
            _assetServiceMock.Setup(x => x.GetAssetsByQuadkey(It.IsAny<string>()))
                             .Returns(mockResult);

            LightningService lightningService = new LightningService(_loggerMock.Object, _assetServiceMock.Object, _notificationServiceMock.Object);

            lightningService.ProcessLightningStrike(mockLightningStrike);

            _notificationServiceMock.Verify(mock => mock.MakeNotification(mockAsset));
        }
        [Fact]
        public void ProcessLightningStrike_Throw_Exeption_For_Invalid_Data()
        {
            Asset mockAsset = new Asset()
            {
                assetName = "Luvinia Union",
                quadKey = "033321123133",
                assetOwner = "7100"
            };
            List<Asset> mockResult = new List<Asset>() { mockAsset };

            LightningStrike mockLightningStrike = new LightningStrike()
            {
                flashType = 1,
                strikeTime = 1446760902720,
                latitude = 350,
                longitude = -12.7052625,
                peakAmps = 3363,
                reserved = "000",
                icHeight = 18467,
                receivedTime = 1446760915182,
                numberOfSensors = 8,
                multiplicity = 3
            };
            _assetServiceMock.Setup(x => x.GetAssetsByQuadkey(It.IsAny<string>()))
                             .Returns(mockResult);

            LightningService lightningService = new LightningService(_loggerMock.Object, _assetServiceMock.Object, _notificationServiceMock.Object);

            Assert.Throws<ArgumentException>(() => lightningService.ProcessLightningStrike(mockLightningStrike));
        }



    }
}
