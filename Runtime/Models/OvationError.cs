using System;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class OvationError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonIgnore]
        public int HttpStatusCode { get; set; }

        [JsonIgnore]
        public bool IsNetworkError { get; set; }

        public override string ToString()
        {
            if (IsNetworkError)
                return $"[Ovation] Network error: {Message}";
            return $"[Ovation] API error ({HttpStatusCode}): {Code} - {Message}";
        }
    }

    [Serializable]
    internal class ErrorResponse
    {
        [JsonProperty("error")]
        public OvationError Error { get; set; }
    }
}
