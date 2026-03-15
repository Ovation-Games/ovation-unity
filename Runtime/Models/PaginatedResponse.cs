using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [System.Serializable]
    public class PaginatedResponse<T>
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; } = new List<T>();

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
