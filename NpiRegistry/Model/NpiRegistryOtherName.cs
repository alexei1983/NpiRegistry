using System.Text.Json.Serialization;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class NpiRegistryOtherName
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("organization_name")]
        public string? OrganizationName { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("middle_name")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("name_suffix")]
        public string? NameSuffix { get; set; }

        [JsonPropertyName("name_prefix")]
        public string? NamePrefix { get; set; }
    }
}
