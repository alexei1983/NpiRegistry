
using System.Text.Json.Serialization;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry.Model
{
    /// <summary>
    /// Represents an external identifier for an individual or organization in the 
    /// National Provider Identifier (NPI) registry.
    /// </summary>
    public class NpiRegistryIdentifier
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("desc")]
        public string? Description { get; set; }

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        [JsonPropertyName("identifier")]
        public string? Identifier { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}
