using System.Text.Json.Serialization;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry.Model
{
    /// <summary>
    /// Represents a record in the National Provider Identifier (NPI) registry.
    /// </summary>
    public class NpiRegistryRecord
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("created_epoch")]
        public long? CreatedEpoch { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("last_updated_epoch")]
        public long? LastUpdatedEpoch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? LastUpdated
        {
            get
            {
                if (LastUpdatedEpoch.HasValue && LastUpdatedEpoch.Value > 0)
                    return DateTimeOffset.FromUnixTimeSeconds(LastUpdatedEpoch.Value);
                return default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? Created
        {
            get
            {
                if (CreatedEpoch.HasValue && CreatedEpoch.Value > 0)
                    return DateTimeOffset.FromUnixTimeSeconds(CreatedEpoch.Value);
                return default;
            }
        }

        [JsonPropertyName("enumeration_type")]
        public string? EnumerationType { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("basic")]
        public NpiRegistryBasicInfo? Basic { get; set; }

        [JsonPropertyName("addresses")]
        public List<NpiRegistryAddress>? Addresses { get; set; }

        [JsonPropertyName("practiceLocations")]
        public List<NpiRegistryAddress>? PracticeLocations { get; set; }

        [JsonPropertyName("taxonomies")]
        public List<NpiRegistryTaxonomy>? Taxonomies { get; set; }

        [JsonPropertyName("identifiers")]
        public List<NpiRegistryIdentifier>? Identifiers { get; set; }

        [JsonPropertyName("endpoints")]
        public List<NpiRegistryEndpoint>? Endpoints { get; set; }

        [JsonPropertyName("other_names")]
        public List<NpiRegistryOtherName>? OtherNames { get; set; }
    }
}
