using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class Achievement
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("repeatable")]
        public bool Repeatable { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("rarity_percentage")]
        public float? RarityPercentage { get; set; }

        [JsonProperty("slot_assets")]
        public Dictionary<string, string> SlotAssets { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("test_mode")]
        public bool TestMode { get; set; }
    }
}
