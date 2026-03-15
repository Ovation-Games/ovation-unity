using System;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class ExternalIdResponse
    {
        [JsonProperty("player_id")]
        public string PlayerId { get; set; }

        [JsonProperty("authority_id")]
        public string AuthorityId { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
    }
}
