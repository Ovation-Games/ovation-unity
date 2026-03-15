using System;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class Asset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("slot_id")]
        public string SlotId { get; set; }

        [JsonProperty("slot_name")]
        public string SlotName { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("authority_attribution")]
        public string AuthorityAttribution { get; set; }

        [JsonProperty("current_version")]
        public int CurrentVersion { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text_content")]
        public string TextContent { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
