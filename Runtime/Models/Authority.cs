using System;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class Authority
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
