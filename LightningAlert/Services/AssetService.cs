using LightningAlert.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace LightningAlert.Services
{
    public interface IAssetService
    {
        List<Asset> GetAssetsByQuadkey(string quadkey);
        void MarkAsNotified(string id);
    }
    public class AssetService : IAssetService
    {
        protected readonly ILogger _logger;
        private IDataAccessService _dataAccessService;
        private List<Asset> _assets;
        public AssetService(ILogger<AssetService> logger, IDataAccessService DataAccessService)
        {
            _logger = logger;
            _dataAccessService= DataAccessService;
            _assets = _dataAccessService.ReadAllAssets();
        }

        public List<Asset> GetAssetsByQuadkey(string quadkey)
        {
            return _assets.Where(a => a.quadKey.Equals(quadkey) && a.notified == false).ToList();
        }
        public void MarkAsNotified(string id)
        {
            _assets.Where(a => a.Id.Equals(id)).ToList().ForEach(s => s.notified = true);
        }
    }
}
