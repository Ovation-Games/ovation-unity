using System;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class AssetSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slot_id")]
        public string SlotId { get; set; }

        [JsonProperty("slot_name")]
        public string SlotName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}
