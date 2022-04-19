using System;

namespace LightningAlert.Model
{
    public class Asset
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string assetName { get; set; }
        public string quadKey { get; set; }
        public string assetOwner { get; set; }
        public bool notified { get; set; } = false;
    }
}
