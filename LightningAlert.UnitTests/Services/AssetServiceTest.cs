using LightningAlert.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xunit;
using LightningAlert.Services;

namespace LightningAlert.UnitTests.Services
{
    public class AssetServiceTest
    {
        private Mock<ILogger<AssetService>> _loggerMock;
        private Mock<IDataAccessService> _dataAccessMock;
        public AssetServiceTest()
        {
            _dataAccessMock = new Mock<IDataAccessService>();
            _loggerMock = new Mock<ILogger<AssetService>>();
        }

        [Fact]
        public void GetAssetsByQuadkey_Return_Asset_WithQuadKey()
        {
            _dataAccessMock.Setup(x => x.ReadAllAssets())
                .Returns(getSampleAssetList());

            AssetService assetService = new AssetService(_loggerMock.Object, _dataAccessMock.Object);

            var asset = assetService.GetAssetsByQuadkey("023112133032");

            Assert.Equal("7100", asset.First().assetOwner);
        }

        [Fact]
        public void GetAssetsByQuadkey_Return_Null_If_Quadkey_Not_Found()
        {
            _dataAccessMock.Setup(x => x.ReadAllAssets())
                .Returns(getSampleAssetList());

            AssetService assetService = new AssetService(_loggerMock.Object, _dataAccessMock.Object);

            var asset = assetService.GetAssetsByQuadkey("0");

            Assert.True(asset.Count == 0);
        }


        private List<Asset> getSampleAssetList()
        {
            List<Asset> assetList = new List<Asset>()
            {
                new Asset()
                {
                    assetName = "Luvinia Union",
                    quadKey = "023112133032",
                    assetOwner = "7100"
                },
                new Asset()
                {
                     assetName = "Quitzon Union",
		             quadKey = "023112133030",
		             assetOwner = "141"
                },
                new Asset()
                {
                     assetName = "Boyle Cape",
                     quadKey = "023112310103",
                     assetOwner = "94908"
                }
            };
            return assetList;
        }
    }
}
