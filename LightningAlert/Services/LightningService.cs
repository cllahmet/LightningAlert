using LightningAlert.Data.Enums;
using LightningAlert.Helpers;
using LightningAlert.Model;
using LightningAlert.Validators;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace LightningAlert.Services
{
    public interface ILightningService
    {
        void ProcessLightningStrike(LightningStrike lightningStrike);
    }
    public class LightningService: ILightningService
    {
        protected readonly ILogger _logger;
        private IAssetService _assetService;
        private INotificationService _notificationService;
        public LightningService(ILogger<LightningService> logger, 
                                IAssetService assetService, 
                                INotificationService notificationService)
        {
            _logger = logger;
            _assetService = assetService;
            _notificationService = notificationService;
        }

        public void ProcessLightningStrike(LightningStrike lightningStrike)
        {
            validatelightningStrikeData(lightningStrike);
            if (lightningStrike.flashType == (int)FlashTypes.heartBeat)
            {
                return;
            }

            string quadKey = TileSystem.LatLongToQuadKey(lightningStrike.latitude, lightningStrike.longitude);
            List<Asset> assets = _assetService.GetAssetsByQuadkey(quadKey);
            foreach(Asset asset in assets)
            {
                _notificationService.MakeNotification(asset);
                _assetService.MarkAsNotified(asset.Id);
            }
        }

        private void validatelightningStrikeData(LightningStrike lightningStrike)
        {
            LightningStrikeValidator validator = new LightningStrikeValidator();
            var result = validator.Validate(lightningStrike);
            if (!result.IsValid)
            {
                var error = result.Errors.FirstOrDefault();
                throw new System.ArgumentException(error.ErrorMessage, error.PropertyName);
            }
        }


    }
}
