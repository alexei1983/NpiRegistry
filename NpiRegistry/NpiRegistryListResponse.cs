
using System.Text.Json.Serialization;
using Llc.GoodConsulting.Interfaces.NpiRegistry.Model;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// 
    /// </summary>
    public class NpiRegistryListResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("result_count")]
        public int ResultCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("results")]
        public List<NpiRegistryRecord>? Results { get; set; }
    }
}
