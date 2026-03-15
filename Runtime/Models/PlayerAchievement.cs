using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class PlayerAchievement
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("authority_id")]
        public string AuthorityId { get; set; }

        [JsonProperty("authority_name")]
        public string AuthorityName { get; set; }

        [JsonProperty("earned_at")]
        public DateTimeOffset EarnedAt { get; set; }

        [JsonProperty("assets")]
        public List<AssetSummary> Assets { get; set; } = new List<AssetSummary>();
    }
}
