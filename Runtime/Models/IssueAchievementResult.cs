using System;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class IssueAchievementResult
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("earned_at")]
        public DateTimeOffset EarnedAt { get; set; }

        [JsonProperty("was_new")]
        public bool WasNew { get; set; }

        /// <summary>
        /// True if the request was queued offline and not yet synced.
        /// </summary>
        [JsonIgnore]
        public bool WasQueued { get; set; }
    }
}
