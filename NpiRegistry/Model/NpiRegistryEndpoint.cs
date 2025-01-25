
using System.Text.Json.Serialization;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class NpiRegistryEndpoint
    {
        [JsonPropertyName("endpointType")]
        public string? EndpointType { get; set; }

        [JsonPropertyName("endpointTypeDescription")]
        public string? EndpointTypeDescription { get; set; }

        [JsonPropertyName("endpoint")]
        public string? Endpoint { get; set; }

        [JsonPropertyName("endpointDescription")]
        public string? EndpointDescription { get; set; }

        [JsonPropertyName("affiliation")]
        public string? Affiliation { get; set; }

        [JsonPropertyName("affiliationName")]
        public string? AffiliationName { get; set; }

        [JsonPropertyName("use")]
        public string? Use { get; set; }

        [JsonPropertyName("useDescription")]
        public string? UseDescription { get; set; }

        [JsonPropertyName("useOtherDescription")]
        public string? UseOtherDescription { get; set; }

        [JsonPropertyName("contentType")]
        public string? ContentType { get; set; }

        [JsonPropertyName("contentTypeDescription")]
        public string? ContentTypeDescription { get; set; }

        [JsonPropertyName("contentOtherDescription")]
        public string? ContentOtherDescription { get; set; }

        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("country_name")]
        public string? CountryName { get; set; }

        [JsonPropertyName("address_type")]
        public string? AddressType { get; set; }

        [JsonPropertyName("address_1")]
        public string? Address1 { get; set; }

        [JsonPropertyName("address_2")]
        public string? Address2 { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }
    }
}
