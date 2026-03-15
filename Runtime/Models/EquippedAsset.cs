using System;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class EquippedAsset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("achievement_slug")]
        public string AchievementSlug { get; set; }

        [JsonProperty("authority_name")]
        public string AuthorityName { get; set; }
    }

    [Serializable]
    public class EquippedSlotResponse
    {
        [JsonProperty("slot")]
        public string Slot { get; set; }

        [JsonProperty("player_id")]
        public string PlayerId { get; set; }

        [JsonProperty("equipped_asset")]
        public EquippedAsset EquippedAsset { get; set; }
    }
}
