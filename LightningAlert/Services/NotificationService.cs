using LightningAlert.Model;
using Microsoft.Extensions.Logging;
using System;

namespace LightningAlert.Services
{
    public interface INotificationService
    {
        void MakeNotification(Asset asset);
    }
    public class NotificationService : INotificationService
    {
        protected readonly ILogger _logger;
        public NotificationService(ILogger<NotificationService> logger)
        {
            _logger = logger;
        }

        public void MakeNotification(Asset asset)
        {
            _logger.LogDebug($"lightning alert for {asset.assetOwner}:{asset.assetName}");
            Console.WriteLine($"lightning alert for {asset.assetOwner}:{asset.assetName}");
        }
    }
}
