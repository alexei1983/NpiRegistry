using System.Text.Json.Serialization;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry.Model
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    public class NpiRegistryTaxonomy
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("taxonomy_group")]
        public string? TaxonomyGroup { get; set; }

        [JsonPropertyName("desc")]
        public string? Description { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("license")]
        public string? License { get; set; }

        [JsonPropertyName("primary")]
        public bool? Primary { get; set; }
    }
}
