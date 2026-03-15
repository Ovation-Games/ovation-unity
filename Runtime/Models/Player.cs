using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class Player
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("anonymous")]
        public bool Anonymous { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("achievements")]
        public List<PlayerAchievement> Achievements { get; set; } = new List<PlayerAchievement>();

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
