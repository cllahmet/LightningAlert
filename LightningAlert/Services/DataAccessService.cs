using LightningAlert.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LightningAlert.Services
{
    public interface IDataAccessService
    {
        List<Asset> ReadAllAssets();
    }
    public class DataAccessService: IDataAccessService
    {
        protected readonly ILogger _logger;
        private readonly string _assetsFileName = "assets.json";
        public DataAccessService(ILogger<AssetService> logger)
        {
            _logger = logger;
        }

        public List<Asset> ReadAllAssets()
        {
            List<Asset> result = new List<Asset>();
            if (File.Exists(_assetsFileName))
            {
                string allAssetsData = File.ReadAllText(_assetsFileName);
                result = JsonConvert.DeserializeObject<List<Asset>>(allAssetsData);
            }
            else
            {
                _logger.LogError($"AssetService :: readData Problem : File Not Found :{_assetsFileName}");
            }
            return result;
        }
    }
}
