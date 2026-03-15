using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ovation.Models
{
    [Serializable]
    public class Slot
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("file_formats")]
        public List<string> FileFormats { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("inner_width")]
        public int? InnerWidth { get; set; }

        [JsonProperty("inner_height")]
        public int? InnerHeight { get; set; }

        [JsonProperty("max_file_size_bytes")]
        public int? MaxFileSizeBytes { get; set; }

        [JsonProperty("transparency")]
        public string Transparency { get; set; }

        [JsonProperty("animation_allowed")]
        public bool AnimationAllowed { get; set; }

        [JsonProperty("text_max_length")]
        public int? TextMaxLength { get; set; }

        [JsonProperty("text_allowed_pattern")]
        public string TextAllowedPattern { get; set; }

        [JsonProperty("authority_guidance")]
        public string AuthorityGuidance { get; set; }

        [JsonProperty("implementation_notes")]
        public string ImplementationNotes { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
